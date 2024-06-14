using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer.Repositories;

namespace Datalayer
{
    public class UnitOfWork
    {
        private CustomerRepository _customerRepository;
        private EntityFramework _dbContext = new EntityFramework();

        public CustomerRepository CustomerRepo
        {
            get
            {
                if(_customerRepository == null)
                    _customerRepository = new CustomerRepository();
                return _customerRepository;
            }
            
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}