using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class GuestBookEntryConfiguration : IEntityTypeConfiguration<GuestBookEntry>
    {
        public void Configure(EntityTypeBuilder<GuestBookEntry> builder)
        {
            builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
            builder.Property(t => t.Entry).HasMaxLength(500).IsRequired();
        }
    }
}
