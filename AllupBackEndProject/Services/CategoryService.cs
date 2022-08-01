using AllupBackEndProject.DAL;
using AllupBackEndProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllupBackEndProject.Services
{
    public class CategoryService : ICategory
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> Category()
        {
            List<Category> categories = _context.Categories
                .Include(p => p.Children)
                .Include(p => p.Products).Where(c => c.IsDeleted != true)
                .ToList();
            return categories;
        }
    }
}
