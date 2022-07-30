using AllupBackEndProject.Models;
using System.Collections.Generic;

namespace AllupBackEndProject.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
