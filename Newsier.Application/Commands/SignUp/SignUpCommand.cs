using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Exceptions;
using Newsier.Application.Helpers;
using Newsier.Application.Interfaces;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.SignUp
{
    public sealed class SignUpCommand : IRequest<string>, IMapTo<Publisher>
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SignUpCommand, Publisher>()
                .ForMember(x => x.Password, opt => opt.MapFrom(x => Convert.ToBase64String(new PasswordHash(x.Password).ToArray())));
        }

        public sealed class Handler : HandlerBase, IRequestHandler<SignUpCommand, string>
        {
            private readonly ITokenService _tokenService;
            private readonly IFileService _fileService;

            public Handler(INewsierContext context, IMapper mapper, ITokenService tokenService, IFileService fileService) : base(context, mapper)
            {
                _tokenService = tokenService;
                _fileService = fileService;
            }

            public async Task<string> Handle(SignUpCommand request, CancellationToken cancellationToken)
            {
                if (await _context.Publishers.AnyAsync(x => x.Email == request.Email))
                    throw new BadRequestException("publisher with this email address already exists");

                Publisher publisher = _mapper.Map<Publisher>(request);
                publisher.Id = Guid.NewGuid().ToString();

                if(request.File != null)
                    publisher.Image = await _fileService.AddFileToDirectoryAsync(request.File, "Assets/Images");

                _context.Publishers.Add(publisher);

                await _context.SaveChangesAsync(cancellationToken);

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
