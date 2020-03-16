using AutoMapper;
using Newsier.Application.Queries.GetPublications;
using Newsier.Application.UnitTests.Common;
using Newsier.Infrastructure;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Newsier.Application.UnitTests.Queries.GetPublications
{
    [Collection("QueryTests")]
    public sealed class GetPublicationsQueryTests
    {
        private readonly NewsierContext _context;
        private readonly IMapper _mapper;

        public GetPublicationsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectList()
        {
            GetPublicationsQuery query = new GetPublicationsQuery();
            GetPublicationsQuery.Handler handler = new GetPublicationsQuery.Handler(_context, _mapper);

            List<PublicationVm> result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<PublicationVm>>();
            result.Count.ShouldBe(6);
        }
    }
}
