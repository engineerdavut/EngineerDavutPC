using RannaPanelManagement.Entities;

namespace RannaPanelManagement.Business.Abstract
{
    public interface IManagerService
    {
        List<Manager> GetAll();
        Manager GetById(int id);
        Manager GetByUsernameAndPassword(string userName, string password);
        void Create(Manager manager);
        void Update(Manager manager);
        void Delete(Manager manager);
    }
}
