using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllupBackEndProject.Models
{
    public class Product:BaseIdentity
    {
        public string ProductCode { get; set; }
        public bool IsFeatured { get; set; }
        public bool BestSeller { get; set; }
        public bool NewArrival { get; set; }
        public bool IsAvailability { get; set; }
        public bool IsSpecial { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double TaxPercent { get; set; }
        public double DiscountPercent { get; set; }
        public int StockCount { get; set; }
        public string Desc { get; set; }

        [NotMapped]
        public int OwnCategory { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; }
        [NotMapped]
        public List<IFormFile> Photos { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductTags> ProductTags { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<BasketItem> BasketItems { get; set; }

    }
}
