using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UiAppSettingReferenceTypeConfiguration : IEntityTypeConfiguration<UiAppSettingReferenceType>
    {
        public void Configure(EntityTypeBuilder<UiAppSettingReferenceType> builder)
        {
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description).IsRequired();
        }
    }
}