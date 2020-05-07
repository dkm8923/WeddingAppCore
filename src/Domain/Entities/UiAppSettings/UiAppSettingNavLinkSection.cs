using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities.UiAppSettings
{
    public class UiAppSettingNavLinkSection
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public string Text { get; set; }
        public string FontAwesomeCss { get; set; }
        public string BadgeText { get; set; }
    }
}
