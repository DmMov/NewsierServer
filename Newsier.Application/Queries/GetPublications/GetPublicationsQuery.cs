using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPublications
{
    public sealed class GetPublicationsQuery : IRequest<List<PublicationVm>>
    {
        public sealed class Handler : IRequestHandler<GetPublicationsQuery, List<PublicationVm>>
        {
            private readonly INewsierContext _context;
            private readonly IMapper _mapper;

            public Handler(INewsierContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<PublicationVm>> Handle(GetPublicationsQuery request, CancellationToken cancellationToken)
            {
                List<PublicationVm> result = await _context.Publications
                    .ProjectTo<PublicationVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return result;
            }
        }
    }
}
