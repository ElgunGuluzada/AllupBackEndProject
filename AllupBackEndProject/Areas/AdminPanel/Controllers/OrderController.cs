using AllupBackEndProject.DAL;
using AllupBackEndProject.Models;
using AllupBackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllupBackEndProject.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public OrderController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Index(string id)
        {
            List<AppUser> appUser = await _userManager.Users.Include(o=>o.Orders).ToListAsync();
            OrderVM orderVM = new OrderVM();
            foreach (var user in appUser)
            {
                List<Order> orders = _context.Orders.Where(a => a.AppUserId == user.Id).Include(o=>o.OrderItems).ToList();
                 orderVM.Orders = orders;
            }

            return View(orderVM);
             
        }
    }
}
