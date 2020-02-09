using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(p => p.Value)
                .IsRequired();
            builder.Property(p => p.PublisherId)
                .IsRequired();
            builder.Property(p => p.CategoryId)
                .IsRequired();
        }
    }
}
