using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetAllPublications
{
    public sealed class GetAllPublicationsQuery : IRequest<List<PublicationItemVm>>
    {
        public sealed class Handler : HandlerBase, IRequestHandler<GetAllPublicationsQuery, List<PublicationItemVm>>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<PublicationItemVm>> Handle(GetAllPublicationsQuery request, CancellationToken cancellationToken)
            {
                List<PublicationItemVm> publications = await _context.Publications
                    .OrderByDescending(x => x.CreatedAt)
                    .ProjectTo<PublicationItemVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return publications;
            }
        }
    }
}
