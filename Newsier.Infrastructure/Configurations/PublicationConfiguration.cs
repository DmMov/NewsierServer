using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Domain.Entities;
using Newsier.Infrastructure.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Newsier.Infrastructure.Configurations
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.Property(p => p.Image)
                .HasMaxLength(256)
                .HasDefaultValue("default-publication.png")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Value)
                .IsRequired();

            builder.Property(p => p.PublisherId)
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(categ => categ.Publications)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Publisher)
                .WithMany(pub => pub.Publications)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedHelper.SeedData<Publication>("publications.json"));
        }
    }
}
