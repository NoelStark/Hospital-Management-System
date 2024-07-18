using EntityLayer;
using Datalayer;
using System.Reflection;

namespace BusinessLayer
{
    public class CustomerController
    {
        private static UnitOfWork _unitOfWork = new UnitOfWork();

        public static void CreateCustomer(Dictionary<string, string> _customerProperties, bool _shareData)
        {
            Customer customer = new Customer();
            foreach (var property in _customerProperties)
            {
                PropertyInfo? propertyInfo = typeof(Customer).GetProperty(property.Key);
                //Outer for-loop checks if property exists and inner loop converts value to type 'long'
                if (propertyInfo != null)
                {
                    if (propertyInfo.PropertyType != typeof(string))
                    {
                        propertyInfo.SetValue(customer, Convert.ToInt64(property.Value));
                        continue;
                    }
                    propertyInfo.SetValue(customer, property.Value);
                }
            }
            customer.ShareData = _shareData;
            
            _unitOfWork.CustomerRepo.Add(customer);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCustomer(Customer customer) => _unitOfWork.CustomerRepo.Update(customer);

        public void RemoveCustomer(Customer customer) => _unitOfWork.CustomerRepo.Remove(customer);
    }
}
