﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using Newsier.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPublicationById
{
    public sealed class GetPublicationByIdQuery : IRequest<PublicationVm>
    {
        public string PublicationId { get; set; }

        public sealed class Handler : HandlerBase, IRequestHandler<GetPublicationByIdQuery, PublicationVm>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<PublicationVm> Handle(GetPublicationByIdQuery request, CancellationToken cancellationToken)
            {
                PublicationVm publicationVm = await _context.Publications
                    .ProjectTo<PublicationVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(publication => publication.Id == request.PublicationId);

                Publication publication = await _context.Publications
                    .SingleOrDefaultAsync(publication => publication.Id == request.PublicationId);

                publication.Views++;

                _context.Publications.Update(publication);

                await _context.SaveChangesAsync(cancellationToken);

                return publicationVm;
            }
        }
    }
}
