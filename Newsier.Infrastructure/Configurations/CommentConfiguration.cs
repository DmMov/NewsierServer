using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Value)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasOne(c => c.Publisher)
                .WithMany(pub => pub.Comments)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.Publication)
                .WithMany(publ => publ.Comments)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}