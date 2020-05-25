﻿using AutoMapper;
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

namespace Newsier.Application.Queries.GetPublicationsByPublisher
{
    public sealed class GetPublicationsByPublisherQuery : IRequest<List<PublicationVm>>
    {
        public string PublisherId { get; set; }

        public sealed class Handler : HandlerBase, IRequestHandler<GetPublicationsByPublisherQuery, List<PublicationVm>>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<PublicationVm>> Handle(GetPublicationsByPublisherQuery request, CancellationToken cancellationToken)
            {
                List<PublicationVm> publications = await _context.Publications
                    .Where(x => x.PublisherId == request.PublisherId)
                    .OrderByDescending(x => x.CreatedAt)
                    .ProjectTo<PublicationVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return publications;
            }
        }
    }
}
