using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Application.Helpers;
using Newsier.Domain.Entities;
using System;

namespace Newsier.Infrastructure.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(p => p.Image)
                .HasMaxLength(256)
                .HasDefaultValue("default-user.png")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.Surname)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Role)
                .HasMaxLength(12)
                .HasDefaultValue("publisher")
                .IsRequired();

            builder.HasData(
                new Publisher
                {
                    Id = "publisher-one",
                    Name = "Volodymyr",
                    Surname = "Mylysiuk",
                    Email = "admin@newsier.com",
                    Password = Convert.ToBase64String(new PasswordHash("admin").ToArray()),
                    Role = "admin",
                    CreatedAt = DateTime.Now,
                    Image = "default-user.png"
                },
                new Publisher
                {
                    Id = "publisher-two",
                    Name = "Dmitriy",
                    Surname = "Movchaniuk",
                    Email = "publisher@newsier.com",
                    Password = Convert.ToBase64String(new PasswordHash("publisher").ToArray()),
                    Role = "publisher",
                    CreatedAt = DateTime.Now,
                    Image = "default-user.png"
                }
            );
        }
    }
}
