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
    public sealed class GetAllPublicationsQuery : IRequest<List<PublicationVm>>
    {
        public sealed class Handler : HandlerBase, IRequestHandler<GetAllPublicationsQuery, List<PublicationVm>>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<PublicationVm>> Handle(GetAllPublicationsQuery request, CancellationToken cancellationToken)
            {
                List<PublicationVm> publications = await _context.Publications
                    .OrderByDescending(x => x.CreatedAt)
                    .ProjectTo<PublicationVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return publications;
            }
        }
    }
}
