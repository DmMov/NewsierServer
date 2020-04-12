using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.Property(p => p.Image)
                .HasMaxLength(256)
                .HasDefaultValue("default-publication.png")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Value)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(categ => categ.Publications)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Publisher)
                .WithMany(pub => pub.Publications)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
