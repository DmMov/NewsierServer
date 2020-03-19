using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPublisher
{
    public sealed class GetPublisherQuery : IRequest<PublisherVm>
    {
        public string PublisherId { get; set; }

        public sealed class Handler : IRequestHandler<GetPublisherQuery, PublisherVm>
        {
            private readonly INewsierContext _context;
            private readonly IMapper _mapper;

            public Handler(INewsierContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PublisherVm> Handle(GetPublisherQuery request, CancellationToken cancellationToken)
            {
                PublisherVm publisher = await _context.Publishers
                    .ProjectTo<PublisherVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(publisher => publisher.Id == request.PublisherId);

                return publisher;
            }
        }
    }
}
