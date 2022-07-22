using AllupBackEndProject.Models;
using System.Collections.Generic;

namespace AllupBackEndProject.ViewModel
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<SliderContent> SliderContents { get; set; }
        public List<Banner> Banners { get; set; }

    }
}
