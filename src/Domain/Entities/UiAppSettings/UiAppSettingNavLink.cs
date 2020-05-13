using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.UiAppSettings
{
    public class UiAppSettingNavLink : AuditableEntity
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
