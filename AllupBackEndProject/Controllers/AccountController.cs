﻿using AllupBackEndProject.Models;
using AllupBackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using static AllupBackEndProject.Helpers.Helper;
using AllupBackEndProject.Helpers;
using Microsoft.Extensions.Configuration;
using AllupBackEndProject.DAL;
using System.Linq;

namespace AllupBackEndProject.Controllers
{
    public class AccountController : Controller
    {


            private readonly UserManager<AppUser> _userManager;
            private readonly RoleManager<IdentityRole> _rolemanager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly AppDbContext _context;
            private readonly IConfiguration _config;
            

            public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager, IConfiguration config, AppDbContext context)
            {
                _userManager = userManager;
                _rolemanager = rolemanager;
                _signInManager = signInManager;
                _config = config;
                _context=context;
            }

            public IActionResult Index()
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("register", "account");
                }
                return View();
            }

            public IActionResult Register()
            {
                ViewBag.brand = _context.Brands.Where(b=>b.IsDeleted!=true).ToList();
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterVM registerVM)
            {
            ViewBag.brand = _context.Brands.Where(b => b.IsDeleted != true).ToList();
            if (!ModelState.IsValid)    
                if (!ModelState.IsValid) return View();
                DateTime now = DateTime.Now;
                DateTime confirm = now.AddMinutes(1);
                AppUser user = new AppUser
                {
                    FullName = registerVM.FirstName + " " + registerVM.LastName,
                    UserName = registerVM.Username,
                    Email = registerVM.Email,
                    UserCreateTime = now,
                    ConfirmMailTime = confirm,
                };

                IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(registerVM);
                }

                await _userManager.AddToRoleAsync(user, UserRoles.Member.ToString());


                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string confirmation = Url.Action("ConfirmEmail", "Account", new
                {
                    token,
                    Email = registerVM.Email
                }, Request.Scheme);

                Helper helper = new Helper(_config.GetSection("ConfirmationParameter:Email").Value, _config.GetSection("ConfirmationParameter:Password").Value);
                var emailResult = helper.SendEmail(registerVM.Email, confirmation);
                if (!emailResult)
                {
                    return View(registerVM);
                }
                return RedirectToAction("login", "account");
            }

            public IActionResult Login()
            {
            ViewBag.brand = _context.Brands.Where(b => b.IsDeleted != true).ToList();
            return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginVM login, string ReturnUrl)
            {
            ViewBag.brand = _context.Brands.Where(b => b.IsDeleted != true).ToList();
            if (!ModelState.IsValid) return View();

                AppUser appUser = await _userManager.FindByEmailAsync(login.Email);
                if (appUser == null)
                {
                    ModelState.AddModelError("", "email or  password is invalid!");
                    return View(login);
                }
                var roles = await _userManager.GetRolesAsync(appUser);
                //var AppUserRole = await _userManager.GetRolesAsync(appUser);
                SignInResult result = await _signInManager.PasswordSignInAsync(appUser, login.Password, true, true);

                TimeSpan time = appUser.ConfirmMailTime.ToUniversalTime() - DateTime.Now.ToUniversalTime();
                var time2 = TimeSpan.FromMinutes(time.TotalMinutes);
                int m = time2.Minutes;
                var s = time2.Seconds;
                foreach (var item in roles)
                {
                    if (result.Succeeded)
                    {
                        ViewBag.Role = item;
                        if (s <= 0 && appUser.EmailConfirmed == false)
                        {
                            await _signInManager.SignOutAsync();
                            await _userManager.DeleteAsync(appUser);
                            ModelState.AddModelError("", "Email Reset! You can use this email again!");
                            return View(login);
                        }
                        else if (item == "Ban")
                        {
                            await _signInManager.SignOutAsync();
                            TempData["Banned"] = "Hesabiniz banlanmisdir";
                            return View(login);
                        }
                        else if (appUser.EmailConfirmed == true && item == "Member")
                        {
                             await _signInManager.SignInAsync(appUser, true);
                             return RedirectToAction("Index", "home");
                    }
                    else if (item.ToLower().Contains("admin"))
                        {
                            await _signInManager.SignInAsync(appUser, true);
                            return RedirectToAction("index", "dashboard", new { area = "AdminPanel" });
                        }
                    }
                }
                ViewBag.Failed = appUser.AccessFailedCount;
                ViewBag.Success = result.Succeeded;
                ViewBag.Email = appUser.EmailConfirmed;
                TempData["User Create Time"] = appUser.UserCreateTime;
                TempData["IsConfirmTime"] = appUser.ConfirmMailTime;
                TempData["QalanVaxt"] = $"{m} deq {s}san erzinde mailinizi tesdiqleyin";
            
                if (result.IsLockedOut)
                {
                    TimeSpan timeSpan = appUser.LockoutEnd.Value.UtcDateTime.ToUniversalTime() - DateTime.Now.ToUniversalTime();
                    var timeSpanFromMinutes = TimeSpan.FromMinutes(timeSpan.TotalMinutes);
                    int mm = timeSpanFromMinutes.Minutes;
                    int ss = timeSpanFromMinutes.Seconds;
                    TempData["Error"] = $"{mm} deq {ss} saniye sonra daxil ola bilersiniz";
                    return View(login);
                }
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "email or  password is invalid!");
                    return View(login);
                }
                if (result == null)
                {
                    ModelState.AddModelError("", "email or  password is invalid!");
                    return View(login);
                }

                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }

                return View();
            }

            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                //var curUser = await _userManager.GetUserAsync(HttpContext.User);
                //await _userManager.DeleteAsync(curUser);
                return RedirectToAction("index", "home");

            }
            public async Task CreateRole()
            {
                foreach (var item in Enum.GetValues(typeof(UserRoles)))
                {
                    if (!await _rolemanager.RoleExistsAsync(item.ToString()))
                    {
                        await _rolemanager.CreateAsync(new IdentityRole { Name = item.ToString() });
                    }
                }
            }

            public async Task<IActionResult> ConfirmEmail(string token, string email)
            {
                AppUser user = await _userManager.FindByEmailAsync(email);
                var result = await _userManager.ConfirmEmailAsync(user, token);

                return View(result.Succeeded ? "ConfirmEmail" : "Error");
            }
    }
}

