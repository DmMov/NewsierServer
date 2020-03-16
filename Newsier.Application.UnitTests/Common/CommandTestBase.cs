using Newsier.Infrastructure;
using System;

namespace Newsier.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        public NewsierContext Context { get; }

        public CommandTestBase()
        {
            Context = NewsierContextFactory.Create();
        }

        public void Dispose()
        {
            NewsierContextFactory.Destroy(Context);
        }
    }
}