using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities.UiAppSettings
{
    public class UiAppSettingNavLink
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
