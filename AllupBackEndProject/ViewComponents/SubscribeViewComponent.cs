using AllupBackEndProject.DAL;
using AllupBackEndProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AllupBackEndProject.ViewComponents
{
    public class SubscribeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public SubscribeViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Subscriber subscriber = _context.Subscribers.FirstOrDefault();
            return View(await Task.FromResult(subscriber));
        }
    }
}

