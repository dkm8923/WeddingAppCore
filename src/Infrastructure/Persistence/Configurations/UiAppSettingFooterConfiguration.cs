using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UiAppSettingFooterConfiguration : IEntityTypeConfiguration<UiAppSettingFooter>
    {
        public void Configure(EntityTypeBuilder<UiAppSettingFooter> builder)
        {
            //builder.Property(t => t.ApplicationId).IsRequired();
        }
    }
}
