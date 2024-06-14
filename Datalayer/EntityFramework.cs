using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace Datalayer
{
    internal class EntityFramework : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
