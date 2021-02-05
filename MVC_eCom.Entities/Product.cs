using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_eCom.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }
    }
}
