using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UiAppSettingNavLinkSectionConfiguration : IEntityTypeConfiguration<UiAppSettingNavLinkSection>
    {
        public void Configure(EntityTypeBuilder<UiAppSettingNavLinkSection> builder)
        {
            builder.Property(t => t.ApplicationId).IsRequired();
            builder.Property(t => t.Text).IsRequired();
        }
    }
}
