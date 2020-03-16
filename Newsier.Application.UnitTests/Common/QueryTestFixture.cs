using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Infrastructure;
using System;
using Xunit;

namespace Newsier.Application.UnitTests.Common
{
    public sealed class QueryTestFixture : IDisposable
    {
        public NewsierContext Context { get; }
        public IMapper Mapper { get; }

        public QueryTestFixture()
        {
            Context = NewsierContextFactory.Create();

            MapperConfiguration configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }
        
        public void Dispose()
        {
            NewsierContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryTests")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}