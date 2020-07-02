using AutoMapper;
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
                Publication publication = await _context.Publications
                    .Include(x => x.Category)
                    .Include(x => x.Publisher)
                    .SingleOrDefaultAsync(publication => publication.Id == request.PublicationId);

                publication.Views++;

                _context.Publications.Update(publication);

                await _context.SaveChangesAsync(cancellationToken);

                PublicationVm response = _mapper.Map<PublicationVm>(publication);

                return response;
            }
        }
    }
}
