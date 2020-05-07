using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UiAppSettingNavLinkConfiguration : IEntityTypeConfiguration<UiAppSettingNavLink>
    {
        public void Configure(EntityTypeBuilder<UiAppSettingNavLink> builder)
        {
            builder.Property(t => t.ApplicationId).IsRequired();
            builder.Property(t => t.Text).IsRequired();
            builder.Property(t => t.Url).IsRequired();
        }
    }
}
