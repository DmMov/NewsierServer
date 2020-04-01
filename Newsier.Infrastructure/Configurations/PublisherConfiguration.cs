using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(p => p.Image)
                .HasMaxLength(256)
                .HasDefaultValue("default-user.png")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.Surname)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Role)
                .HasMaxLength(12)
                .HasDefaultValue("publisher")
                .IsRequired();
        }
    }
}
