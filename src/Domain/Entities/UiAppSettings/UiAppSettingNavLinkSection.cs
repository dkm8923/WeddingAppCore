using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.UiAppSettings
{
    public class UiAppSettingNavLinkSection : AuditableEntity
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public string Text { get; set; }
        public string FontAwesomeCss { get; set; }
        public string BadgeText { get; set; }
    }
}
