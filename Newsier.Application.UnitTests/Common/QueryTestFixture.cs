using System;
using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Infrastructure;
using Xunit;

namespace Newsier.Application.UnitTests.Common
{
    public sealed class QueryTestFixture : IDisposable
    {
        public QueryTestFixture()
        {
            Context = NewsierDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }
        public NewsierDbContext Context { get; }

        public IMapper Mapper { get; }

        public void Dispose()
        {
            NewsierDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryTests")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}