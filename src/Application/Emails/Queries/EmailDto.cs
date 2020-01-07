using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Emails.Queries
{
    public class EmailDto : AuditableEntity, IMapFrom<Domain.Entities.Email>
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
