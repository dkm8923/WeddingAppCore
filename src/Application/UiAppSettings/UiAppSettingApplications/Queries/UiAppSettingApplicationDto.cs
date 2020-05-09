using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.UiAppSettings;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingApplications.Queries
{
    public class UiAppSettingApplicationDto : AuditableEntity, IMapFrom<UiAppSettingApplication>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
