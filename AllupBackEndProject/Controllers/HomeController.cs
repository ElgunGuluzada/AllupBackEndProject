using AllupBackEndProject.DAL;
using AllupBackEndProject.ViewModels;
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
            var products =await _context.Products.Include(p=>p.ProductImages).ToListAsync();
            HomeVM homeVM = new HomeVM();
            homeVM.SliderContents = await _context.SliderContents.Include(s => s.Slider).ToListAsync();
            homeVM.Banners=await _context.Banners.ToListAsync();
            homeVM.Categories = await _context.Categories.Include(c=>c.Children).ToListAsync();
            homeVM.Brands= await _context.Brands.ToListAsync();
            homeVM.Products= await _context.Products
                .Include(p=>p.Category)
                .Include(p=>p.Brand)
                .Include(p => p.ProductImages)
                .ToListAsync();
            homeVM.ProductImages=await _context.ProductImages.Include(i=>i.Product).ToListAsync();

            var newProduct = products.Where(p=>p.NewArrival).ToList();
            var isFeatured = products.Where(p=>p.IsFeatured).ToList();
            var bestSeller = products.Where(p=>p.BestSeller).ToList();

            ViewBag.newProduct = newProduct;
            ViewBag.isFeatured = isFeatured;
            ViewBag.bestSeller = bestSeller;
            return View(homeVM);
        }
    }
}
