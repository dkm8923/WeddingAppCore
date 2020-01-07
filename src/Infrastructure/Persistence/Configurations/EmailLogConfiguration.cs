using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class EmailLogConfiguration : IEntityTypeConfiguration<EmailLog>
    {
        public void Configure(EntityTypeBuilder<EmailLog> builder)
        {
            builder.Property(t => t.EmailId).IsRequired();
            builder.Property(t => t.SentDate).IsRequired();
            builder.Property(t => t.SentBy).HasMaxLength(200).IsRequired();
        }
    }
}
