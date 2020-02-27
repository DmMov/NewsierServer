using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newsier.Application.Helpers;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;

namespace Newsier.Infrastructure.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            string defaultUserImgUrl = "https://localhost:5001/Static/Images/default-user.png";

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

            builder.Property(p => p.ImageUrl)
                .HasDefaultValue(defaultUserImgUrl)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasData(
                new Publisher
                {
                    Id = "publisher-one",
                    Name = "Volodymyr",
                    Surname = "Mylysiuk",
                    Role = "admin",
                    Created = DateTime.Now,
                    Password = Convert.ToBase64String(new PasswordHash("admin").ToArray())
                },
                new Publisher
                {
                    Id = "publisher-two",
                    Name = "Dmitriy",
                    Surname = "Movchaniuk",
                    Role = "publisher",
                    Created = DateTime.Now,
                    Password = Convert.ToBase64String(new PasswordHash("publisher").ToArray())
                }
            );
        }
    }
}
