using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using System;

namespace CleanArchitecture.Application.GuestBookEntries.Queries
{
    public class GuestBookEntryDto : AuditableEntity, IMapFrom<EmailLog>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Entry { get; set; }
        public bool? Approved { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }
}