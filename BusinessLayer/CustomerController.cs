using EntityLayer;
using Datalayer;

namespace BusinessLayer
{
    public class CustomerController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public void AddCustomer(Customer customer) => unitOfWork.CustomerRepo.Add(customer);

        public void UpdateCustomer(Customer customer) => unitOfWork.CustomerRepo.Update(customer);

        public void RemoveCustomer(Customer customer) => unitOfWork.CustomerRepo.Remove(customer);
    }
}
