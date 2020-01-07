using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class WeddingDescriptionConfiguration : IEntityTypeConfiguration<WeddingDescription>
    {
        public void Configure(EntityTypeBuilder<WeddingDescription> builder)
        {
            builder.Property(t => t.GroomDescription).HasMaxLength(500).IsRequired();
            builder.Property(t => t.BrideDescription).HasMaxLength(500).IsRequired();
            builder.Property(t => t.CeremonyDateTimeLocation).HasMaxLength(2000).IsRequired();
            builder.Property(t => t.CeremonyDescription).HasMaxLength(2000).IsRequired();
            builder.Property(t => t.ReceptionDateTimeLocation).HasMaxLength(2000).IsRequired();
            builder.Property(t => t.ReceptionDescription).HasMaxLength(2000).IsRequired();
        }
    }
}
