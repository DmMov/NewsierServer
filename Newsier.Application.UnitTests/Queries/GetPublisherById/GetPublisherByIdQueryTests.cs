using AutoMapper;
using Newsier.Application.Queries.GetPublisherById;
using Newsier.Application.UnitTests.Common;
using Newsier.Application.ViewModels;
using Newsier.Infrastructure;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Newsier.Application.UnitTests.Queries.GetPublisherById
{
    [Collection("QueryTests")]
    public sealed class GetPublisherByIdQueryTests
    {
        private readonly NewsierContext _context;
        private readonly IMapper _mapper;

        public GetPublisherByIdQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData("test-publisher-1")]
        [InlineData("test-publisher-2")]
        public async Task Handle_GivenCorrectPublisherId_ShouldReturnCorrectVm(string publisherId)
        {
            GetPublisherByIdQuery query = new GetPublisherByIdQuery { PublisherId = publisherId };
            GetPublisherByIdQuery.Handler handler = new GetPublisherByIdQuery.Handler(_context, _mapper);

            PublisherVm result = await handler.Handle(query, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<PublisherVm>();
        }
    }
}
