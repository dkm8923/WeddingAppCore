using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using System;

namespace CleanArchitecture.Application.Families.Queries
{
    public class FamilyDto : AuditableEntity, IMapFrom<Family>
    {
        public long Id { get; set; }
        public long GuestId { get; set; }
        public string ConfirmationCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long StateId { get; set; }
        public string Zip { get; set; }
        public bool? Attending { get; set; }
    }
}
