﻿using FluentValidation;

namespace Newsier.Application.Commands.DeletePublication
{
    public sealed class DeletePublicationCommandValidator : AbstractValidator<DeletePublicationCommand>
    {
        public DeletePublicationCommandValidator()
        {
            RuleFor(x => x.PublicationId)
                .NotEmpty()
                .WithMessage("'PublicationId' is null or an empty string");
        }
    }
}
