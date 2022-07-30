using AllupBackEndProject.Models;
using System.Collections.Generic;

namespace AllupBackEndProject.ViewModels
{
    public class UserDetailVM
    {
        public int Id { get; set; }
        public AppUser appUser { get; set; }
        public List<Order> orders { get; set; }
    }
}
