﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Exceptions;
using Newsier.Application.Helpers;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.SignIn
{
    public sealed class SignInCommand : IRequest<SignInResponseVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public sealed class Handler : IRequestHandler<SignInCommand, SignInResponseVm>
        {
            private readonly INewsierContext _context;
            private readonly ITokenService _tokenService;

            public Handler(INewsierContext context, ITokenService tokenService)
            {
                _context = context;
                _tokenService = tokenService;
            }

            public async Task<SignInResponseVm> Handle(SignInCommand request, CancellationToken cancellationToken)
            {
                Publisher publisher = await _context.Publishers.
                    SingleOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower());

                if (publisher == null)
                    throw new BadRequestException("incorect email or password");

                byte[] hashBytes = Convert.FromBase64String(publisher.Password);

                PasswordHash hash = new PasswordHash(hashBytes);

                SignInResponseVm vm = new SignInResponseVm();

                if (!hash.Verify(request.Password))
                    throw new BadRequestException("incorect email or password");

                ICollection<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, publisher.Id),
                    new Claim(ClaimTypes.Role, publisher.Role)
                };

                vm.Token = _tokenService.BuildToken(claims);

                return vm;
            }
        }
    }
}
