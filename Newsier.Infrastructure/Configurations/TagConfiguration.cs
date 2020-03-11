using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;
using System;

namespace Newsier.Infrastructure.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Value)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasData(
                new Tag
                {
                    Id = "tag-one",
                    Value = "hello",
                    CreatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = "tag-two",
                    Value = "welcome",
                    CreatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = "tag-three",
                    Value = "decisions",
                    CreatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = "tag-four",
                    Value = "2020",
                    CreatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = "tag-five",
                    Value = "dress",
                    CreatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = "tag-six",
                    Value = "job",
                    CreatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = "tag-seven",
                    Value = "world actions",
                    CreatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = "tag-eight",
                    Value = "cool science",
                    CreatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = "tag-nine",
                    Value = "tech 2020",
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}
