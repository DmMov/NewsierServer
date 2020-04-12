using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    public class TagToPublicationConfiguration : IEntityTypeConfiguration<TagToPublication>
    {
        public void Configure(EntityTypeBuilder<TagToPublication> builder)
        {
            builder.HasOne(tp => tp.Publication)
                .WithMany(p => p.TagsToPublications)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(tp => tp.Tag)
                .WithMany(t => t.TagsToPublications)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
