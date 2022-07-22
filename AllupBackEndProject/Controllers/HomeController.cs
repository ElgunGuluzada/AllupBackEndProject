using AllupBackEndProject.DAL;
using AllupBackEndProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AllupBackEndProject.Controllers
{

    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.SliderContents = _context.SliderContents.Include(s => s.Slider).ToList();
            homeVM.Banners=_context.Banners.ToList();
            //homeVM.Categories=_context.Categories.Where(c=>c.ImageUrl!=null).ToList();
            homeVM.Categories = await _context.Categories.ToListAsync();

            return View(homeVM);
        }
    }
}
