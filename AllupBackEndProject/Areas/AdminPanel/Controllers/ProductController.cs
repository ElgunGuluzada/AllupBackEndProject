using AllupBackEndProject.DAL;
using AllupBackEndProject.Extentions;
using AllupBackEndProject.Helpers;
using AllupBackEndProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AllupBackEndProject.Areas.AdminPanel.Controllers
{
    [Area("adminpanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private IWebHostEnvironment _env;
        private readonly IConfiguration _config;


        public ProductController(AppDbContext context, IWebHostEnvironment env,UserManager<AppUser> userManager,IConfiguration config)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .ThenInclude(p => p.Tag)
                .ToListAsync();
            return View(allProducts);
        }

        public async Task<IActionResult> Create()
        {
            var allCategories = await _context.Categories.ToListAsync();
            var mainCategories = allCategories.Where(p => p.ParentId == null).Where(p => p.IsDeleted != true).ToList();
            var altCategories = allCategories.Where(c => c.ParentId != null).Where(p => p.IsDeleted != true).ToList();
            ViewBag.altCategories = new SelectList((altCategories).ToList(), "Id", "Name");
            ViewBag.ProductBrands = new SelectList(_context.Brands.Where(p => p.IsDeleted != true).ToList(), "Id", "Name");
            ViewBag.mainCategories = new SelectList((mainCategories).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(_context.Tags.Where(p => p.IsDeleted != true).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var allCategories = await _context.Categories.ToListAsync();
            var mainCategories = allCategories.Where(p => p.ParentId == null).Where(p => p.IsDeleted != true).ToList();
            var altCategories = allCategories.Where(c => c.ParentId != null).Where(p => p.IsDeleted != true).ToList();
            ViewBag.altCategories = new SelectList((altCategories).ToList(), "Id", "Name");
            ViewBag.ProductBrands = new SelectList(_context.Brands.Where(p => p.IsDeleted != true).ToList(), "Id", "Name");
            ViewBag.mainCategories = new SelectList((mainCategories).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(_context.Tags.Where(p => p.IsDeleted != true).ToList(), "Id", "Name");

            if (product.Name == null)
            {
                ModelState.AddModelError("Name", "Category Name Cannot be Empty!");
                return View();
            }
            bool existProductName = _context.Products.Where(c => c.IsDeleted != true).Any(c => c.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (existProductName)
            {
                ModelState.AddModelError("Name", "The name of product is exist");
                return View();
            }

            List<ProductImage> images = new List<ProductImage>();
            if (product.Photos == null) return BadRequest();
            foreach (var item in product.Photos)
            {
                if (item == null)
                {
                    ModelState.AddModelError("Photo", "Don't be Empty");
                    return View();
                }
                if (!item.IsImage())
                {
                    ModelState.AddModelError("Photo", "Only Image Files");
                    return View();
                }

                if (item.ValidSize(2000))
                {
                    ModelState.AddModelError("Photo", "Size oversize");
                    return View();
                }
                ProductImage image = new ProductImage();
                image.ImageUrl = item.SaveImage(_env, "assets/images/product");

                if (product.Photos.Count == 1)
                {
                    image.IsMain = true;
                }
                else
                {
                    for (int i = 0; i < images.Count; i++)
                    {
                        images[0].IsMain = true;
                    }
                }
                images.Add(image);
            }

            if (!ModelState.IsValid) return View();

            Product newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                ProductImages = images,
                StockCount = product.StockCount,
                IsDeleted = false,
                IsAvailability = true,
                IsFeatured = false,
                DiscountPercent = product.DiscountPercent,
                DiscountPrice = product.Price - (product.Price * product.DiscountPercent) / 100,
                BrandId = product.BrandId,
                TaxPercent = product.TaxPercent,
                Desc = product.Desc,
                CreatedAt = System.DateTime.Now
            };
            if (product.OwnCategory == null)
            {
                newProduct.CategoryId = product.CategoryId;
            }
            else
            {
                newProduct.CategoryId = product.OwnCategory;
            }
            List<ProductTags> productTags = new List<ProductTags>();
            foreach (int item in product.TagIds)
            {
                ProductTags productTag = new ProductTags();
                productTag.TagId = item;
                productTag.ProductId = newProduct.Id;
                productTags.Add(productTag);
            }
            newProduct.ProductTags = productTags;

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            List<Subscriber> subscribers  = await _context.Subscribers.ToListAsync();
            var token = "";
            Helper helper = new Helper(_config.GetSection("ConfirmationParameter:Email").Value, _config.GetSection("ConfirmationParameter:Password").Value);
            foreach (var subscriber in subscribers)
            {
                token = $"Salam yeni mehsullarimiz burada https://localhost:44341/ ";
                var emailResult = helper.SendNews(subscriber.Email, token);
                continue;
            }
            string confirmation = Url.Action("ConfirmEmail", "Account", new
            {
                token
            }, Request.Scheme);

           
            return RedirectToAction("index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            var allCategories = await _context.Categories.ToListAsync();
            var mainCategories = allCategories.Where(p => p.ParentId == null).Where(p => p.IsDeleted != true).ToList();
            var altCategories = allCategories.Where(c => c.ParentId != null).Where(p => p.IsDeleted != true).ToList();
            ViewBag.altCategories = new SelectList((altCategories).ToList(), "Id", "Name");
            ViewBag.ProductBrands = new SelectList(_context.Brands.Where(p => p.IsDeleted != true).ToList(), "Id", "Name");
            ViewBag.mainCategories = new SelectList((mainCategories).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(_context.Tags.Where(p => p.IsDeleted != true).ToList(), "Id", "Name");
            if (id == null) return NotFound();
            var tag = await _context.Tags.Where(c => c.IsDeleted != true).ToListAsync();

            Product dbProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .ThenInclude(t => t.Tag)
                .Include(b => b.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (dbProduct == null) return NotFound();
            return View(dbProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            var tags = await _context.Tags.Where(p => p.IsDeleted != true).ToListAsync();
            var allCategories = await _context.Categories.ToListAsync();
            var mainCategories = allCategories.Where(p => p.ParentId == null).Where(p => p.IsDeleted != true).ToList();
            var altCategories = allCategories.Where(c => c.ParentId != null).Where(p => p.IsDeleted != true).ToList();
            ViewBag.altCategories = new SelectList((altCategories).ToList(), "Id", "Name");
            ViewBag.ProductBrands = new SelectList(_context.Brands.Where(p => p.IsDeleted != true).ToList(), "Id", "Name");
            ViewBag.mainCategories = new SelectList((mainCategories).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(tags.Where(p => p.IsDeleted != true).ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product dbProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .ThenInclude(t => t.Tag)
                .Include(b => b.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.Id == product.Id);
            if (dbProduct == null)
            {
                return View();
            }
            List<ProductImage> images = new List<ProductImage>();
            Product dbProductName = _context.Products.FirstOrDefault(c => c.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            string path = "";
            
            if (product.Photos == null)
            {
                foreach (var item in dbProduct.ProductImages)
                {
                    item.ImageUrl = item.ImageUrl;
                    _context.ProductImages.Add(item);
                }
            }
            else
            {
                foreach (var item in product.Photos)
                {
                    if (item == null)
                    {
                        ModelState.AddModelError("Photo", "Don't be Empty");
                        return View();
                    }
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Only Image Files");
                        return View();
                    }

                    if (item.ValidSize(2000))
                    {
                        ModelState.AddModelError("Photo", "Size oversize");
                        return View();
                    }
                    ProductImage image = new ProductImage();
                    image.ImageUrl = item.SaveImage(_env, "assets/images/product");

                    if (product.Photos.Count == 1)
                    {
                        image.IsMain = true;
                    }
                    else
                    {
                        for (int i = 0; i < images.Count; i++)
                        {
                            images[0].IsMain = true;
                        }
                    }
                    images.Add(image);
                }

                foreach (var item in product.Photos)
                {
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Only Image Files");
                        return View();
                    }

                    if (item.ValidSize(1000))
                    {
                        ModelState.AddModelError("Photo", "Size is higher max 1mb");
                        return View();
                    }
                }
            }

            foreach (var item in dbProduct.ProductImages)
            {
                if (item.ImageUrl != null)
                {
                    path = Path.Combine(_env.WebRootPath, "assets/images/product", item.ImageUrl);
                }
            }
            if (path != null)
            {
                Helpers.Helper.DeleteImage(path);
            }
            else return NotFound();

            if (dbProductName != null)
            {
                if (dbProduct.Name != dbProduct.Name)
                {
                    ModelState.AddModelError("Name", "This Name already was taken");
                    return View();
                }
            }
            if (product.TagIds==null)
            {
                foreach (var item1 in dbProduct.ProductTags)
                {
                    item1.TagId = item1.TagId;
                }
            }
            else
            {
                List<ProductTags> productTags = new List<ProductTags>();
                foreach (int item in product.TagIds)
                {
                    ProductTags productTag = new ProductTags();
                    productTag.TagId = item;
                    productTag.ProductId = dbProduct.Id;
                    productTags.Add(productTag);
                }
                dbProduct.ProductTags = productTags;
            }
            if (product.Category == null && product.OwnCategory == null)
            {
                dbProduct.CategoryId = dbProduct.OwnCategory;
            }
            else
            {
                dbProduct.CategoryId = product.OwnCategory;
            }


            if (product.StockCount==0)
            {
                dbProduct.IsAvailability = false;
            }
            List<Category> categories = _context.Categories.Where(p=>p.IsDeleted!=true).Where(c=>c.ImageUrl!=null).ToList();
            for (int i = 0; i < categories.Count; i++)
            {
                if (product.Category==categories[0])
                {
                    dbProduct.CategoryId = dbProduct.OwnCategory;
                }
            }

            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.ProductImages = images;

            dbProduct.StockCount = product.StockCount;
            dbProduct.IsDeleted = false;
            dbProduct.IsFeatured = false;
            dbProduct.DiscountPercent = product.DiscountPercent;
            dbProduct.DiscountPrice = product.Price - (product.Price * product.DiscountPercent) / 100;
            dbProduct.BrandId = product.BrandId;
            dbProduct.TaxPercent = product.TaxPercent;
            dbProduct.Desc = product.Desc;
            dbProduct.UptadetAt = System.DateTime.Now;
            await _context.SaveChangesAsync();


            //List<Subscriber> subscribers = await _context.Subscribers.ToListAsync();
            //var token = "";
            //Helper helper = new Helper(_config.GetSection("ConfirmationParameter:Email").Value, _config.GetSection("ConfirmationParameter:Password").Value);
            //foreach (var subscriber in subscribers)
            //{
            //    if (dbProduct.DiscountPrice / product.Price == 2)
            //    {
            //        token = $" Mehsulun qiymeti 50% Endirildi https://preview.themeforest.net/item/allup-electronics-ecommerce-html5-template/full_screen_preview/27042714?_ga=2.98090911.1817295916.1659218963-1275575051.1654878103&_gac=1.53084506.1657637222.CjwKCAjwt7SWBhAnEiwAx8ZLaqavzy2p1AcQEh_emgIhVWjEcAPZTJRguybkfDIygO_xWE2VdK6vvhoChPYQAvD_BwE ";
            //        var emailResult = helper.DiscountPrice(subscriber.Email, token);
            //    }
            //    else if (dbProduct.DiscountPrice / product.Price < 2)
            //    {
            //        token = $" Mehsulun qiymeti 50% daha artiq Endirildi https://preview.themeforest.net/item/allup-electronics-ecommerce-html5-template/full_screen_preview/27042714?_ga=2.98090911.1817295916.1659218963-1275575051.1654878103&_gac=1.53084506.1657637222.CjwKCAjwt7SWBhAnEiwAx8ZLaqavzy2p1AcQEh_emgIhVWjEcAPZTJRguybkfDIygO_xWE2VdK6vvhoChPYQAvD_BwE ";
            //        var emailResult = helper.DiscountPrice(subscriber.Email, token);
            //    }
            //    continue;
            //}
            //string confirmation = Url.Action("ConfirmEmail", "Account", new
            //{
            //    token
            //}, Request.Scheme);

            return RedirectToAction("Index");
        }
        public IActionResult LoadSubCategory(int id)
        {
            var subCategory = _context.Categories.Where(s => s.ParentId == id).Where(s => s.IsDeleted != true).Select(c => new { id = c.Id, name = c.Name }).ToList();
            return Json(subCategory);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.Include(c => c.Category)
                .Include(c => c.ProductTags)
                .ThenInclude(t => t.Tag)
                .Include(pi => pi.ProductImages)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbProduct == null) return NotFound();
            return View(dbProduct);
        }
    }
}
