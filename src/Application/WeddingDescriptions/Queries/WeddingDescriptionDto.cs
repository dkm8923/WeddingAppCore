using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.WeddingDescriptions.Queries
{
    public class WeddingDescriptionDto : IMapFrom<WeddingDescription>
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
