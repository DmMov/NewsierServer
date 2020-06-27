using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.Property(x => x.Image)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Value)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Publications)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Publisher)
                .WithMany(x => x.Publications)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
