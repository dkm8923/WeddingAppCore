using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.UiAppSettings;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Queries
{
    public class UiAppSettingFooterDto : AuditableEntity, IMapFrom<UiAppSettingFooter>
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public string TextLeft { get; set; }
        public string TextMiddle { get; set; }
        public string TextRight { get; set; }
    }
}
