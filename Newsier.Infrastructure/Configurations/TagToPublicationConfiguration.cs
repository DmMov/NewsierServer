using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;

namespace Newsier.Infrastructure.Configurations
{
    public class TagToPublicationConfiguration : IEntityTypeConfiguration<TagToPublication>
    {
        public void Configure(EntityTypeBuilder<TagToPublication> builder)
        {
            builder.HasOne(x => x.Publication)
                .WithMany(x => x.TagsToPublications)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.TagsToPublications)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
