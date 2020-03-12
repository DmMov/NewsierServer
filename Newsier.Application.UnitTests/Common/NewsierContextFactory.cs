using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Newsier.Application.Helpers;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using Newsier.Infrastructure;
using System;

namespace Newsier.Application.UnitTests.Common
{
    public static class NewsierContextFactory
    {
        public static NewsierContext Create()
        {
            var options = new DbContextOptionsBuilder<NewsierContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var context = new NewsierContext(options, dateTimeMock.Object);

            context.Database.EnsureCreated();

            context.Publishers.AddRange(
                  new Publisher()
                  {
                      Id = "one",
                      Image = "default-user.png",
                      Name = "Name",
                      Surname = "Surname",
                      Email = "test@email.com",
                      Password = Convert.ToBase64String(new PasswordHash("publisher").ToArray()),
                      Role = "admin",
                      CreatedAt = DateTime.Now,
                      LastModifiedAt = DateTime.Now
                  }
              );

            context.Categories.AddRange(
                new Category()
                {
                    Id = "one",
                    Name = "categ",
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now
                }
            );

            context.Publications.AddRange(
                new Publication
                {
                    Id = "one",
                    Image = "default-publication.png",
                    Title = "title",
                    Value = "value",
                    Views = 37,
                    CategoryId = "one",
                    PublisherId = "one",
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now
                }
            );

            context.SaveChanges();

            return context;
        }

        public static void Destroy(NewsierContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}