using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using Newsier.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPublisherById
{
    public sealed class GetPublisherByIdQuery : IRequest<PublisherVm>
    {
        public string PublisherId { get; set; }

        public sealed class Handler : HandlerBase, IRequestHandler<GetPublisherByIdQuery, PublisherVm>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<PublisherVm> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
            {
                Publisher publisher = await _context.Publishers
                    .Include(x => x.Publications)
                    .Include(x => x.Comments)
                    .SingleOrDefaultAsync(publisher => publisher.Id == request.PublisherId);

                PublisherVm response = _mapper.Map<PublisherVm>(publisher);

                return response;
            }
        }
    }
}
