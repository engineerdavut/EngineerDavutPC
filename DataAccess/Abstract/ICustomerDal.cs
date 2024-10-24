using RannaPanelManagement.Core.DataAccess;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.DataAccess.Abstract
{
    public interface ICustomerDal : IRepository<Customer>
    {
        Customer GetByUsernameAndPassword(string userName, string password);
    }
}
