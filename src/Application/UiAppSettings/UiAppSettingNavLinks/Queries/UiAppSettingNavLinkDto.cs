using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.UiAppSettings;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Queries
{
    public class UiAppSettingNavLinkDto : AuditableEntity, IMapFrom<UiAppSettingNavLink>
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public long? NavLinkSectionId { get; set; }
        public string Text { get; set; }
        public string FontAwesomeCss { get; set; }
        public string Url { get; set; }
        public string BadgeText { get; set; }
    }
}
