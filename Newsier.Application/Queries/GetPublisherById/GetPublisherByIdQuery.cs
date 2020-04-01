using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPublisherById
{
    public sealed class GetPublisherByIdQuery : IRequest<PublisherVm>
    {
        public string PublisherId { get; set; }

        public sealed class Handler : QueryHandlerBase, IRequestHandler<GetPublisherByIdQuery, PublisherVm>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<PublisherVm> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
            {
                PublisherVm publisher = await _context.Publishers
                    .ProjectTo<PublisherVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(publisher => publisher.Id == request.PublisherId);

                return publisher;
            }
        }
    }
}
