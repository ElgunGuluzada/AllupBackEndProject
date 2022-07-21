using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllupBackEndProject.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }
    }
}
