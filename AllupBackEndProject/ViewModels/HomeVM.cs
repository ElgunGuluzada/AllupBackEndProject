using AllupBackEndProject.Models;
using System.Collections.Generic;

namespace AllupBackEndProject.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<SliderContent> SliderContents { get; set; }
        public List<Banner> Banners { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
