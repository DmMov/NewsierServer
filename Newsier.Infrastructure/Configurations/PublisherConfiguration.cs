using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(x => x.Image)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasMaxLength(12)
                .HasDefaultValue("publisher")
                .IsRequired();
        }
    }
}
