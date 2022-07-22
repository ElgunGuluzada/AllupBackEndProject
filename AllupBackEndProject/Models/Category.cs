using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AllupBackEndProject.Models
{
    public class Category:BaseIdentity
    {
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
    }
}
