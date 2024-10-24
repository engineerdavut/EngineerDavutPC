using RannaPanelManagement.Core.DataAccess;
using RannaPanelManagement.DataAccess.Abstract;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.DataAccess.Concrete
{
    public class ManagerDal : EntityFrameworkBase<Manager, AppDbContext>, IManagerDal
    {
        public Manager GetByUsernameAndPassword(string userName, string password)
        {
            using (var context = new AppDbContext())
            {
                return context.Managers
                              .FirstOrDefault(c => c.UserName == userName && c.Password == password);
            }
        }

    }
}
