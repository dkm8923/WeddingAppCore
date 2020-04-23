using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.UiAppSettings;

namespace CleanArchitecture.Application.UiAppSettings.Queries
{
    public class UiAppSettingDto : AuditableEntity, IMapFrom<UiAppSetting>
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public long ReferenceTypeId { get; set; }
        public string Json { get; set; }
    }
}
