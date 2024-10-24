using Microsoft.AspNet.Identity;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer GetByUsernameAndPassword(string userName, string password);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
