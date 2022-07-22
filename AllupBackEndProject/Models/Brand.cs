using System.Collections.Generic;

namespace AllupBackEndProject.Models
{
    public class Brand:BaseIdentity
    {
        public List<Product> Products { get; set; }
    }
}
