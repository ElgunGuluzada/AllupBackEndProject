using System.Collections.Generic;

namespace AllupBackEndProject.Models
{
    public class Tag:BaseIdentity
    { 
        public List<ProductTags> ProductTags { get; set; }
    }
}
