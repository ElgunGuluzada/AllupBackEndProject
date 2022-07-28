using AllupBackEndProject.Models;
using System.Collections.Generic;

namespace AllupBackEndProject.ViewModels
{
    public class UserVM
    {
        public List<AppUser> Users { get; set; }
        public IList<string> userRoles { get; set; }
        public string UserId { get; set; }
    }
}
