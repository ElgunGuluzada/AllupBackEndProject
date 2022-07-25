using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllupBackEndProject.Models
{
    public class Category:BaseIdentity
    {
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public List<Product> Products { get; set; }
    }
}
