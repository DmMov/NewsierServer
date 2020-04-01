using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetPublisherById
{
    public sealed class GetPublisherByIdQueryValidator : AbstractValidator<GetPublisherByIdQuery>
    {
        private readonly INewsierContext _context;

        public GetPublisherByIdQueryValidator(INewsierContext context)
        {
            _context = context;

            RuleFor(query => query.PublisherId)
                .NotEmpty()
                .WithMessage("'PublisherId' is null or an empty string")
                .MustAsync(Exist)
                .WithMessage("There is no publisher with the specified 'PublisherId'");
        }

        public async Task<bool> Exist(string publisherId, CancellationToken cancellationToken)
        {
            return await _context.Publishers
                .AnyAsync(publisher => publisher.Id == publisherId, cancellationToken);
        }
    }
}
