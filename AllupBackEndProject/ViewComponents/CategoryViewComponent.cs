using AllupBackEndProject.DAL;
using AllupBackEndProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllupBackEndProject.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public CategoryViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int skip)
        {
            List<Category> categories = _context.Categories.Where(c=>c.ImageUrl!=null).Skip(skip).Take(4).ToList();
            return View(await Task.FromResult(categories));
        }
    }
}
