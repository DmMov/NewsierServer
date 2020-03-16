using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;
using System;

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

            builder.Property(p => p.PublisherId)
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(categ => categ.Publications)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Publisher)
                .WithMany(pub => pub.Publications)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Publication {
                    Id = "publication-one",
                    Title = "the first publication",
                    Value = "the content of the very first publication on the web-site",
                    CreatedAt = DateTime.Now,
                    CategoryId = "category-one",
                    PublisherId = "publisher-one",
                    Image = "image"
                },
                new Publication
                {
                    Id = "publication-two",
                    Title = "the second publication",
                    Value = "the content of the second publication on the web-site",
                    CreatedAt = DateTime.Now,
                    CategoryId = "category-one",
                    PublisherId = "publisher-two",
                    Image = "image"
                },
                new Publication
                {
                    Id = "publication-three",
                    Title = "the third publication",
                    Value = "the content of the third publication on the web-site",
                    CreatedAt = DateTime.Now,
                    CategoryId = "category-two",
                    PublisherId = "publisher-one",
                    Image = "image"
                },
                new Publication
                {
                    Id = "publication-four",
                    Title = "the fourth publication",
                    Value = "the content of the fourth publication on the web-site",
                    CreatedAt = DateTime.Now,
                    CategoryId = "category-two",
                    PublisherId = "publisher-two",
                    Image = "image"
                },
                new Publication
                {
                    Id = "publication-five",
                    Title = "the fifth publication",
                    Value = "the content of the fifth publication on the web-site",
                    CreatedAt = DateTime.Now,
                    CategoryId = "category-three",
                    PublisherId = "publisher-one",
                    Image = "image"
                },
                new Publication
                {
                    Id = "publication-six",
                    Title = "the sixth publication",
                    Value = "the content of the sixth publication on the web-site",
                    CreatedAt = DateTime.Now,
                    CategoryId = "category-three",
                    PublisherId = "publisher-two",
                    Image = "image"
                }
            );
        }
    }
}
