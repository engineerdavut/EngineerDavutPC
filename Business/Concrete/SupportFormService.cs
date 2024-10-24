using RannaPanelManagement.Entities;
using System.Collections.Generic;
using System.Linq;
using RannaPanelManagement.DataAccess.Concrete;
using RannaPanelManagement.DataAccess.Abstract;
using RannaPanelManagement.Business.Abstract;

namespace RannaPanelManagement.Business.Concrete
{
    public class SupportFormService : ISupportFormService
    {
        private readonly ISupportFormDal _supportFormDal;

        public SupportFormService(ISupportFormDal supportFormDal)
        {
            _supportFormDal = supportFormDal;
        }

        public List<SupportForm> GetAll()
        {
            return _supportFormDal.GetAll();
        }

        public SupportForm GetById(int id)
        {
            return _supportFormDal.Get(sf => sf.Id == id);
        }

        public void Create(SupportForm supportForm)
        {
            _supportFormDal.Add(supportForm);
        }

        public void Update(SupportForm supportForm)
        {
            _supportFormDal.Update(supportForm);
        }

        public void Delete(SupportForm supportForm)
        {
            _supportFormDal.Delete(supportForm);
        }
    }
}
