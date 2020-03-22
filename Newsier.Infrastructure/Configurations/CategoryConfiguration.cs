using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;
using Newsier.Infrastructure.Helpers;

namespace Newsier.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.HasData(SeedHelper.SeedData<Category>("categories.json"));
        }
    }
}
