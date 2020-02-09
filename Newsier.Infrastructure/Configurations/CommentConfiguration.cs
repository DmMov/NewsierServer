using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
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
        }
    }
}
