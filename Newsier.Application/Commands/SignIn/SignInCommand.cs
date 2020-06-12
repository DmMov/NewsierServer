using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Exceptions;
using Newsier.Application.Helpers;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.SignIn
{
    public sealed class SignInCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public sealed class Handler : IRequestHandler<SignInCommand, string>
        {
            private readonly INewsierContext _context;
            private readonly ITokenService _tokenService;

            public Handler(INewsierContext context, ITokenService tokenService)
            {
                _context = context;
                _tokenService = tokenService;
            }

            public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
            {
                Publisher publisher = await _context.Publishers.
                    FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower());

                if (publisher == null)
                    throw new BadRequestException("email or password incorrect.");

                byte[] hashBytes = Convert.FromBase64String(publisher.Password);

                PasswordHash hash = new PasswordHash(hashBytes);

                if (!hash.Verify(request.Password))
                    throw new BadRequestException("email or password incorrect.");

                ICollection<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, publisher.Id),
                    new Claim(ClaimTypes.Role, publisher.Role)
                };

                string token = _tokenService.BuildToken(claims);

                return token;
            }
        }
    }
}
