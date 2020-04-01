using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

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
        }
    }
}
