using RannaPanelManagement.Business.Abstract;
using RannaPanelManagement.DataAccess.Abstract;
using RannaPanelManagement.DataAccess.Concrete;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.Business.Concrete
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerDal _managerDal;

        public ManagerService(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public List<Manager> GetAll()
        {
            return _managerDal.GetAll();
        }
        public Manager GetByUsernameAndPassword(string userName, string password)
        {
            return _managerDal.GetByUsernameAndPassword(userName, password);
        }

        public Manager GetById(int id)
        {
            return _managerDal.Get(m => m.Id == id);
        }

        public void Create(Manager manager)
        {
            _managerDal.Add(manager);
        }

        public void Update(Manager manager)
        {
            _managerDal.Update(manager);
        }

        public void Delete(Manager manager)
        {
            _managerDal.Delete(manager);
        }
    }
}
