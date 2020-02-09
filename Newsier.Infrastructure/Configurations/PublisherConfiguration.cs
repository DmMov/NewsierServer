using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;

namespace Newsier.Infrastructure.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.Surname)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.Role)
                .HasMaxLength(12)
                .HasDefaultValue("publisher")
                .IsRequired();

            builder.HasData(
                new Publisher { Id = "publisher-one", Name = "Volodymyr", Surname = "Mylysiuk", Role = "admin", Created =  DateTime.Now },
                new Publisher { Id = "publisher-two", Name = "Dmitriy", Surname = "Movchaniuk", Role = "publisher", Created = DateTime.Now }
            );
        }
    }
}
