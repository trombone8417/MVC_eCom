using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_eCom.Entities
{
    public class Category : BaseEntity
    {
        public string ImageURL { get; set; }
        public List<Product> Products { get; set; }
    }
}
