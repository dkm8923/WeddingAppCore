using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.Property(t => t.FirstName).HasMaxLength(500).IsRequired();
            builder.Property(t => t.LastName).HasMaxLength(500).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(2000).IsRequired();
        }
    }
}
