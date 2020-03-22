using Microsoft.EntityFrameworkCore;
using Moq;
using Newsier.Application.Interfaces;
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

            return context;
        }

        public static void Destroy(NewsierContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}