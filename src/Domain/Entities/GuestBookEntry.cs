using CleanArchitecture.Domain.Common;
using System;

namespace CleanArchitecture.Domain.Entities
{
    public class GuestBookEntry : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Entry { get; set; }
        public bool? Approved { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }
}
