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
                    Created = DateTime.Now,
                    TagId = "tag-one",
                    PublicationId = "publication-one"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-two",
                    Created = DateTime.Now,
                    TagId = "tag-two",
                    PublicationId = "publication-one"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-three",
                    Created = DateTime.Now,
                    TagId = "tag-three",
                    PublicationId = "publication-one"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-four",
                    Created = DateTime.Now,
                    TagId = "tag-four",
                    PublicationId = "publication-two"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-five",
                    Created = DateTime.Now,
                    TagId = "tag-five",
                    PublicationId = "publication-two"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-six",
                    Created = DateTime.Now,
                    TagId = "tag-six",
                    PublicationId = "publication-three"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-seven",
                    Created = DateTime.Now,
                    TagId = "tag-seven",
                    PublicationId = "publication-three"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-eight",
                    Created = DateTime.Now,
                    TagId = "tag-eight",
                    PublicationId = "publication-three"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-nine",
                    Created = DateTime.Now,
                    TagId = "tag-nine",
                    PublicationId = "publication-three"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-ten",
                    Created = DateTime.Now,
                    TagId = "tag-one",
                    PublicationId = "publication-four"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-eleven",
                    Created = DateTime.Now,
                    TagId = "tag-two",
                    PublicationId = "publication-four"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-twelve",
                    Created = DateTime.Now,
                    TagId = "tag-three",
                    PublicationId = "publication-five"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-thirteen",
                    Created = DateTime.Now,
                    TagId = "tag-four",
                    PublicationId = "publication-five"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-fourteen",
                    Created = DateTime.Now,
                    TagId = "tag-five",
                    PublicationId = "publication-six"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-fifteen",
                    Created = DateTime.Now,
                    TagId = "tag-six",
                    PublicationId = "publication-six"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-sixteen",
                    Created = DateTime.Now,
                    TagId = "tag-seven",
                    PublicationId = "publication-six"
                },
                new TagToPublication
                {
                    Id = "tag-to-publication-seventeen",
                    Created = DateTime.Now,
                    TagId = "tag-eight",
                    PublicationId = "publication-six"
                }
            );
        }
    }
}
