using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UiAppSettingApplicationConfiguration : IEntityTypeConfiguration<UiAppSettingApplication>
    {
        public void Configure(EntityTypeBuilder<UiAppSettingApplication> builder)
        {
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description).IsRequired();
        }
    }
}
