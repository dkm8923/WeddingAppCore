using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using System;

namespace CleanArchitecture.Application.EmailLogs.Queries
{
    public class EmailLogDto : AuditableEntity, IMapFrom<EmailLog>
    {
        public long Id { get; set; }
        public int EmailId { get; set; }
        public DateTime SentDate { get; set; }
        public string SentBy { get; set; }
    }
}
