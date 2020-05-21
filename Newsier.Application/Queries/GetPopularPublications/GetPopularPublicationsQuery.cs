﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPopularPublications
{
    public sealed class GetPopularPublicationsQuery : IRequest<List<PublicationVm>>
    {
        public short? Count { get; set; }

        public sealed class Handler : QueryHandlerBase, IRequestHandler<GetPopularPublicationsQuery, List<PublicationVm>>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<PublicationVm>> Handle(GetPopularPublicationsQuery request, CancellationToken cancellationToken)
            {
                List<PublicationVm> publications = await _context.Publications
                    .Where(x => x.CreatedAt > DateTime.Now.AddMonths(-1))
                    .OrderByDescending(x => x.Views)
                    .ProjectTo<PublicationVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                if (request.Count != null)
                    publications = publications
                        .Take(request.Count.Value)
                        .ToList();

                return publications;
            }
        }
    }
}
