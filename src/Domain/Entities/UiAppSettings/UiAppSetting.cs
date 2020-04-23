using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities.UiAppSettings
{
    public class UiAppSetting : AuditableEntity
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public long ReferenceTypeId { get; set; }
        public string Json { get; set; }
    }
}
