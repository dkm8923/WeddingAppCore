using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.UiAppSettings;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Queries
{
    public class UiAppSettingNavLinkSectionDto : AuditableEntity, IMapFrom<UiAppSettingNavLinkSection>
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public string Text { get; set; }
        public string FontAwesomeCss { get; set; }
        public string BadgeText { get; set; }
    }
}
