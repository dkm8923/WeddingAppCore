using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Email : AuditableEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
