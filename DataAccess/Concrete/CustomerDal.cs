using RannaPanelManagement.Core.DataAccess;
using RannaPanelManagement.Entities;
using RannaPanelManagement.DataAccess.Abstract;

namespace RannaPanelManagement.DataAccess.Concrete
{
    public class CustomerDal : EntityFrameworkBase<Customer, AppDbContext>, ICustomerDal
    {
        public Customer GetByUsernameAndPassword(string userName, string password)
        {
            using (var context = new AppDbContext())
            {
                return context.Customers
                              .FirstOrDefault(c => c.UserName == userName && c.Password == password);
            }
        }
    }
}
