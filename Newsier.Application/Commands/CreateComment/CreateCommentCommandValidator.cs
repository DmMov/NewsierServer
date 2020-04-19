using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.CreateComment
{
    public sealed class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        private readonly INewsierContext _context;

        public CreateCommentCommandValidator(INewsierContext context)
        {
            _context = context;

            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("'Value' is null or an empty string")
                .MinimumLength(5)
                .WithMessage("'Value' length must be greater than 5 characters")
                .MaximumLength(256)
                .WithMessage("'Value' length must not be greater than 256 characters");

            RuleFor(x => x.PublicationId)
                .NotEmpty()
                .WithMessage("'PublicationId' is null or an empty string")
                .MustAsync(Exist<Publication>)
                .WithMessage("There is no publication with the specified 'PublicationId'");

            RuleFor(x => x.PublisherId)
                .NotEmpty()
                .WithMessage("'PublisherId' is null or an empty string")
                .MustAsync(Exist<Publisher>)
                .WithMessage("There is no publisher with the specified 'PublisherId'");
        }

        public async Task<bool> Exist<TEntity>(string id, CancellationToken cancellationToken) where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>()
                .AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}