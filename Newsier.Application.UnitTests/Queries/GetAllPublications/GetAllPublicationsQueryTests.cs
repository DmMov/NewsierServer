using AutoMapper;
using Newsier.Application.Queries.GetAllPublications;
using Newsier.Application.UnitTests.Common;
using Newsier.Application.ViewModels;
using Newsier.Infrastructure;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Newsier.Application.UnitTests.Queries.GetAllPublications
{
    [Collection("QueryTests")]
    public sealed class GetAllPublicationsQueryTests
    {
        private readonly NewsierContext _context;
        private readonly IMapper _mapper;

        public GetAllPublicationsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ShouldReturnCorrectListAndElementsCount()
        {
            GetAllPublicationsQuery query = new GetAllPublicationsQuery();
            GetAllPublicationsQuery.Handler handler = new GetAllPublicationsQuery.Handler(_context, _mapper);

            List<PublicationVm> result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<PublicationVm>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBe(5);
        }
    }
}
