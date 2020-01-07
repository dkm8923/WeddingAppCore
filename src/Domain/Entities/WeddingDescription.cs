using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class WeddingDescription : AuditableEntity
    {
        public long Id { get; set; }
        public string GroomDescription { get; set; }
        public string BrideDescription { get; set; }
        public string CeremonyDateTimeLocation { get; set; }
        public string CeremonyDescription { get; set; }
        public string ReceptionDateTimeLocation { get; set; }
        public string ReceptionDescription { get; set; }
    }
}
