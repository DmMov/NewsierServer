using Newsier.Infrastructure;
using System;

namespace Newsier.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        public CommandTestBase()
        {
            Context = NewsierDbContextFactory.Create();
        }

        public NewsierDbContext Context { get; }

        public void Dispose()
        {
            NewsierDbContextFactory.Destroy(Context);
        }
    }
}