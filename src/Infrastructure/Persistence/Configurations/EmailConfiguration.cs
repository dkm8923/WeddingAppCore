using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.Property(t => t.Description).HasMaxLength(500).IsRequired();
            builder.Property(t => t.Subject).HasMaxLength(500).IsRequired();
            builder.Property(t => t.Body).HasMaxLength(2000).IsRequired();
        }
    }
}
