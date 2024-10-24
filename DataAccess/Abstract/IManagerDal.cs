using RannaPanelManagement.Core.DataAccess;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.DataAccess.Abstract
{
    public interface IManagerDal : IRepository<Manager>
    {
        Manager GetByUsernameAndPassword(string userName, string password);
    }
}
