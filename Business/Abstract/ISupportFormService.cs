using RannaPanelManagement.Entities;

namespace RannaPanelManagement.Business.Abstract
{
    public interface ISupportFormService
    {
        List<SupportForm> GetAll();
        SupportForm GetById(int id);
        void Create(SupportForm supportForm);
        void Update(SupportForm supportForm);
        void Delete(SupportForm supportForm);
    }
}
