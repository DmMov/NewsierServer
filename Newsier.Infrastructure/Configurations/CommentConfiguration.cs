using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;
using System;

namespace Newsier.Infrastructure.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Value)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.PublicationId)
                .IsRequired();

            builder.Property(c => c.PublisherId)
                .IsRequired();

            builder.HasOne(c => c.Publisher)
                .WithMany(pub => pub.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Publication)
                .WithMany(publ => publ.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Comment
                {
                    Id = "comment-one",
                    Value = "the publication is cool",
                    Created = DateTime.Now,
                    PublicationId = "publication-one",
                    PublisherId = "publisher-one"
                },
                new Comment
                {
                    Id = "comment-two",
                    Value = "the publication is cool",
                    Created = DateTime.Now,
                    PublicationId = "publication-one",
                    PublisherId = "publisher-one"
                },
                new Comment
                {
                    Id = "comment-three",
                    Value = "the publication is cool",
                    Created = DateTime.Now,
                    PublicationId = "publication-one",
                    PublisherId = "publisher-one"
                },
                new Comment
                {
                    Id = "comment-four",
                    Value = "the publication is cool",
                    Created = DateTime.Now,
                    PublicationId = "publication-one",
                    PublisherId = "publisher-one",
                    ParentId = "comment-one"
                },
                new Comment
                {
                    Id = "comment-five",
                    Value = "the publication is cool",
                    Created = DateTime.Now,
                    PublicationId = "publication-one",
                    PublisherId = "publisher-one",
                    ParentId = "comment-one"
                },
                new Comment
                {
                    Id = "comment-six",
                    Value = "the publication is cool",
                    Created = DateTime.Now,
                    PublicationId = "publication-one",
                    PublisherId = "publisher-one",
                    ParentId = "comment-two"
                }
            );
        }
    }
}