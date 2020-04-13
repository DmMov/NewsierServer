using AutoMapper;
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
    public sealed class GetPublicationByIdQuery : IRequest<DetailedPublicationVm>
    {
        public string PublicationId { get; set; }

        public sealed class Handler : QueryHandlerBase, IRequestHandler<GetPublicationByIdQuery, DetailedPublicationVm>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<DetailedPublicationVm> Handle(GetPublicationByIdQuery request, CancellationToken cancellationToken)
            {
                DetailedPublicationVm publicationVm = await _context.Publications
                    .ProjectTo<DetailedPublicationVm>(_mapper.ConfigurationProvider)
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
