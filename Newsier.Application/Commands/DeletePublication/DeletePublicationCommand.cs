using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Exceptions;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.DeletePublication
{
    public sealed class DeletePublicationCommand : IRequest<string>
    {
        public string PublicationId { get; set; }

        public sealed class Handler : IRequestHandler<DeletePublicationCommand, string>
        {
            private readonly INewsierContext _context;

            public Handler(INewsierContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
            {
                Publication publication = await _context.Publications
                    .SingleOrDefaultAsync(x => x.Id == request.PublicationId);

                if (publication == null)
                    throw new NotFoundException(nameof(Publication), request.PublicationId);

                _context.TagsToPublications.RemoveRange(publication.TagsToPublications);

                _context.Publications.Remove(publication);

                await _context.SaveChangesAsync(cancellationToken);

                return publication.Id;
            }
        }
    }
}
