using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities.UiAppSettings
{
    public class UiAppSettingFooter
    {
        public long Id { get; set; }
        public long? ApplicationId { get; set; }
        public string TextLeft { get; set; }
        public string TextMiddle { get; set; }
        public string TextRight { get; set; }
        
    }
}
