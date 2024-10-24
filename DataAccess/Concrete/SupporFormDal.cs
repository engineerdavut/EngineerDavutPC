using RannaPanelManagement.Core.DataAccess;
using RannaPanelManagement.DataAccess.Abstract;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.DataAccess.Concrete
{
    public class SupportFormDal : EntityFrameworkBase<SupportForm, AppDbContext>, ISupportFormDal
    {

    }
}
