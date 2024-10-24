using System.Collections.Generic;
using System.Linq;
using RannaPanelManagement.Business.Abstract;
using RannaPanelManagement.DataAccess.Abstract;
using RannaPanelManagement.DataAccess.Concrete;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }
        public Customer GetByUsernameAndPassword(string userName, string password)
        {
            return _customerDal.GetByUsernameAndPassword(userName, password);
        }

        public Customer GetById(int id)
        {
            return _customerDal.Get(c => c.Id == id);
        }

        public void Create(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }
    }
}
