using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Customer : Person
    {
        public int CustomerID { get; set; }
        public DateTime AccountCreationDate { get; set; }
    }
}
