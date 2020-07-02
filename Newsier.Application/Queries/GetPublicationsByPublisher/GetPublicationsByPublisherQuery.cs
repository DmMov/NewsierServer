using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using Newsier.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPublicationsByPublisher
{
    public sealed class GetPublicationsByPublisherQuery : IRequest<List<PublicationItemVm>>
    {
        public string PublisherId { get; set; }

        public sealed class Handler : HandlerBase, IRequestHandler<GetPublicationsByPublisherQuery, List<PublicationItemVm>>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<PublicationItemVm>> Handle(GetPublicationsByPublisherQuery request, CancellationToken cancellationToken)
            {
                IQueryable<Publication> publications = _context.Publications
                    .AsQueryable();
                Publisher publisher = await _context.Publishers
                    .FirstOrDefaultAsync(x => x.Id == request.PublisherId);

                if (publisher.Role != "admin")
                    publications = publications
                        .Where(x => x.Id == publisher.Id);

                List<PublicationItemVm> response = await publications
                    .OrderByDescending(x => x.CreatedAt)
                    .ProjectTo<PublicationItemVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return response;
            }
        }
    }
}
