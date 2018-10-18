using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeInChilThings.Domain.Entities;

namespace TradeInChilThings.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Thing> Things { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
