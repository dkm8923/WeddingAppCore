using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UsaStateConfiguration : IEntityTypeConfiguration<UsaState>
    {
        public void Configure(EntityTypeBuilder<UsaState> builder)
        {
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.AbbreviatedName).HasMaxLength(50).IsRequired();
        }
    }
}
