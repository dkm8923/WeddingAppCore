using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Family : AuditableEntity
    {
        public long Id { get; set; }
        public long GuestId { get; set; }
        public string ConfirmationCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long StateId { get; set; }
        public string Zip { get; set; }
        public bool Attending { get; set; }
    }
}
