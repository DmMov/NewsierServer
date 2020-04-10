using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetCommentsByPublication
{
    public sealed class GetCommentsByPublicationQueryValidator : AbstractValidator<GetCommentsByPublicationQuery>
    {
        private readonly INewsierContext _context;

        public GetCommentsByPublicationQueryValidator(INewsierContext context)
        {
            _context = context;

            RuleFor(query => query.PublicationId)
                .NotEmpty()
                .WithMessage("'PublicationId' is null or an empty string")
                .MustAsync(Exist)
                .WithMessage("The specified 'PublicationId' is invalid");
        }

        public async Task<bool> Exist(string publicationId, CancellationToken cancellationToken)
        {
            return await _context.Publications
                .AnyAsync(publication => publication.Id == publicationId, cancellationToken);
        }
    }
}
