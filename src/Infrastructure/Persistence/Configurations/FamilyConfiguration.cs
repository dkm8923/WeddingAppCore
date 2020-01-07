using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.Property(t => t.GuestId).IsRequired();
            builder.Property(t => t.ConfirmationCode).IsRequired();
            builder.Property(t => t.Address1).HasMaxLength(1000).IsRequired();
            builder.Property(t => t.Address2).HasMaxLength(200).IsRequired();
            builder.Property(t => t.City).HasMaxLength(200).IsRequired();
            builder.Property(t => t.StateId).IsRequired();
            builder.Property(t => t.Zip).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Attending).IsRequired();
        }
    }
}
