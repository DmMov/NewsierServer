using Microsoft.EntityFrameworkCore;
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
            DbContextOptions<NewsierContext> options = new DbContextOptionsBuilder<NewsierContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Mock<IDateTime> dateTimeMock = new Mock<IDateTime>();

            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            NewsierContext context = new NewsierContext(options, dateTimeMock.Object);

            context.Database.EnsureCreated();

            SeedTestData(context);

            return context;
        }

        public static void SeedTestData(NewsierContext context)
        {
            context.Publishers.AddRange(
                new Publisher
                {
                    Id = "test-publisher-1",
                    Name = "test",
                    Surname = "admin",
                    Email = "testadmin@newsier.com",
                    Password = Convert.ToBase64String(new PasswordHash("testadmin").ToArray()),
                    Role = "admin",
                    Image = "test-imag"
                },
                new Publisher
                {
                    Id = "test-publisher-2",
                    Name = "test",
                    Surname = "publisher",
                    Email = "testpublisher@newsier.com",
                    Password = Convert.ToBase64String(new PasswordHash("testpublisher").ToArray()),
                    Role = "publisher",
                    Image = "test-imag"
                }
            );

            context.Categories.AddRange(
                new Category
                {
                    Id = "test-categ-1",
                    Name = "test categ one"
                },
                new Category
                {
                    Id = "test-categ-2",
                    Name = "test categ two"
                }
            );

            context.Publications.AddRange(
                new Publication
                {
                    Id = "test-publication-1",
                    Image = "test-image",
                    Title = "title of the first test publication",
                    Value = "value of the first test publication",
                    Views = 122,
                    PublisherId = "test-publisher-1",
                    CategoryId = "test-categ-1"
                },
                new Publication
                {
                    Id = "test-publication-2",
                    Image = "test-image",
                    Title = "title of the second test publication",
                    Value = "value of the second test publication",
                    Views = 17,
                    PublisherId = "test-publisher-1",
                    CategoryId = "test-categ-1"
                },
                new Publication
                {
                    Id = "test-publication-3",
                    Image = "test-image",
                    Title = "title of the third test publication",
                    Value = "value of the third test publication",
                    Views = 127,
                    PublisherId = "test-publisher-2",
                    CategoryId = "test-categ-1"
                },
                new Publication
                {
                    Id = "test-publication-4",
                    Image = "test-image",
                    Title = "title of the fourth test publication",
                    Value = "value of the fourth test publication",
                    Views = 22,
                    PublisherId = "test-publisher-2",
                    CategoryId = "test-categ-2"
                },
                new Publication
                {
                    Id = "test-publication-5",
                    Image = "test-image",
                    Title = "title of the fifth test publication",
                    Value = "value of the fifth test publication",
                    Views = 76,
                    PublisherId = "test-publisher-2",
                    CategoryId = "test-categ-2"
                }
            );

            context.Comments.AddRange(
                new Comment
                {
                    Id = "test-comment-1",
                    Value = "value of the first comment",
                    PublisherId = "test-publisher-1",
                    PublicationId = "test-publication-3"
                },
                new Comment
                {
                    Id = "test-comment-2",
                    Value = "value of the second comment",
                    PublisherId = "test-publisher-1",
                    PublicationId = "test-publication-4"
                },
                new Comment
                {
                    Id = "test-comment-3",
                    Value = "value of the third comment",
                    PublisherId = "test-publisher-2",
                    PublicationId = "test-publication-1"
                },
                new Comment
                {
                    Id = "test-comment-4",
                    Value = "value of the fourth comment",
                    PublisherId = "test-publisher-2",
                    PublicationId = "test-publication-1"
                },
                new Comment
                {
                    Id = "test-comment-5",
                    Value = "value of the fifth comment",
                    PublisherId = "test-publisher-2",
                    PublicationId = "test-publication-3",
                    ParentId = "test-comment-1"
                }
            );

            context.SaveChanges();
        }

        public static void Destroy(NewsierContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}