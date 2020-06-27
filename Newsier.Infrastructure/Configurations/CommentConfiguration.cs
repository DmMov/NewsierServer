using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Value)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasOne(x => x.Publisher)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Publication)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}