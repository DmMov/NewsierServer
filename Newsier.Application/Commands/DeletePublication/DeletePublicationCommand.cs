using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Exceptions;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
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
            private readonly IFileService _fileService;

            public Handler(INewsierContext context, IFileService fileService)
            {
                _context = context;
                _fileService = fileService;
            }

            public async Task<string> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
            {
                Publication publication = await _context.Publications
                    .SingleOrDefaultAsync(x => x.Id == request.PublicationId);

                if (publication == null)
                    throw new NotFoundException(nameof(Publication), request.PublicationId);

                _context.TagsToPublications.RemoveRange(publication.TagsToPublications);

                if(publication.Comments.Count != 0)
                    _context.Comments.RemoveRange(publication.Comments);

                if(publication.Image != "default-publication.png")
                    await _fileService.RemoveFileFromDirectoryAsync(publication.Image, "Assets/Images");

                _context.Publications.Remove(publication);

                await _context.SaveChangesAsync(cancellationToken);

                return publication.Id;
            }
        }
    }
}
