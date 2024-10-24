using RannaPanelManagement.Core.Entity;

namespace RannaPanelManagement.Entities
{
    public class SupportForm:IEntity
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public string State { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
