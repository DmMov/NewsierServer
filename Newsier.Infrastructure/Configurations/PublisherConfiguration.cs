using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(p => p.Surname)
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(p => p.Role)
                .HasMaxLength(12)
                .HasDefaultValue("publisher")
                .IsRequired();
        }
    }
}
