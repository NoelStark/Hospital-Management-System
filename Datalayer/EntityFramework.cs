using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace Datalayer
{
    public class EntityFramework : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    "");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
