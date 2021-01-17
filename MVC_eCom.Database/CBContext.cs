using MVC_eCom.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_eCom.Database
{
    public class CBContext : DbContext,IDisposable
    {
        public CBContext(): base("MVC_eComConnection")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
