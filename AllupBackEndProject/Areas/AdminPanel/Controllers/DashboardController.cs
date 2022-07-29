using AllupBackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _17._06._2022_FrontToBack.Areas.adminPanel.Controllers
{
    [Area("adminpanel")]
    public class DashboardController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var curUser = await _userManager.GetUserAsync(HttpContext.User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AdminUser = User.Identity.Name;
            }
            return View();
        }

    }
}
