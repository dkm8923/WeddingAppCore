using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.UiAppSettings;

namespace CleanArchitecture.Application.UiAppSettingReferenceTypes.Queries
{
    public class UiAppSettingReferenceTypeDto : AuditableEntity, IMapFrom<UiAppSettingReferenceType>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
