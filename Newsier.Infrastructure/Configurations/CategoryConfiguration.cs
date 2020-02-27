using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using Newsier.Infrastructure.Services;
using System;

namespace Newsier.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.HasData(
                new Category
                {
                    Id = "category-one",
                    Name = "fashion",
                    Created = DateTime.Now
                },
                new Category
                {
                    Id = "category-two",
                    Name = "tech",
                    Created = DateTime.Now
                },
                new Category
                {
                    Id = "category-three",
                    Name = "health",
                    Created = DateTime.Now
                }
            );
        }
    }
}
