using Newsier.Infrastructure;
using System;

namespace Newsier.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        public CommandTestBase()
        {
            Context = NewsierContextFactory.Create();
        }

        public NewsierContext Context { get; }

        public void Dispose()
        {
            NewsierContextFactory.Destroy(Context);
        }
    }
}