using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UiAppSettingConfiguration : IEntityTypeConfiguration<UiAppSetting>
    {
        public void Configure(EntityTypeBuilder<UiAppSetting> builder)
        {
            builder.Property(t => t.ApplicationId).IsRequired();
            builder.Property(t => t.ReferenceTypeId).IsRequired();
            builder.Property(t => t.Json).IsRequired();
        }
    }
}
