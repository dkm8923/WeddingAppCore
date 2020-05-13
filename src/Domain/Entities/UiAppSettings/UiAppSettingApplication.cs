using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.UiAppSettings
{
    public class UiAppSettingApplication : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
