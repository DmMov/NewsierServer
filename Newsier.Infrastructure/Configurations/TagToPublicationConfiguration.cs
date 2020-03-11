using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;
using System;

namespace Newsier.Infrastructure.Configurations
{
    public class TagToPublicationConfiguration : IEntityTypeConfiguration<TagToPublication>
    {
        public void Configure(EntityTypeBuilder<TagToPublication> builder)
        {
            builder.Property(tp => tp.TagId)
                .IsRequired();

            builder.Property(tp => tp.PublicationId)
                .IsRequired();

            builder.HasData(
                new TagToPublication
                {
                    Id = "tag-to-publication-one",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-one",
                    PublicationId = "publication-one"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-two",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-two",
                    PublicationId = "publication-one"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-three",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-three",
                    PublicationId = "publication-one"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-four",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-four",
                    PublicationId = "publication-two"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-five",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-five",
                    PublicationId = "publication-two"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-six",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-six",
                    PublicationId = "publication-three"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-seven",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-seven",
                    PublicationId = "publication-three"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-eight",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-eight",
                    PublicationId = "publication-three"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-nine",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-nine",
                    PublicationId = "publication-three"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-ten",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-one",
                    PublicationId = "publication-four"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-eleven",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-two",
                    PublicationId = "publication-four"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-twelve",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-three",
                    PublicationId = "publication-five"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-thirteen",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-four",
                    PublicationId = "publication-five"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-fourteen",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-five",
                    PublicationId = "publication-six"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-fifteen",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-six",
                    PublicationId = "publication-six"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-sixteen",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-seven",
                    PublicationId = "publication-six"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-seventeen",
                    CreatedAt = DateTime.Now,
                    TagId = "tag-eight",
                    PublicationId = "publication-six"
                }
            );
        }
    }
}
