using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Commands.CreatePublication
{
    public sealed class CreatePublicationCommand : IRequest<string>, IMapTo<Publication>
    {
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string CategoryId { get; set; }
        public string Tags { get; set; }
        public string PublisherId { get; set; }

        public sealed class Handler: HandlerBase, IRequestHandler<CreatePublicationCommand, string>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<string> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
            {
                string folderName = "Assets/Images";
                string currentDirectory = Directory.GetCurrentDirectory();
                string newPath = Path.Combine(currentDirectory, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                string fileName = Guid.NewGuid().ToString() + ContentDispositionHeaderValue.Parse(request.File.ContentDisposition).FileName.Trim();
                string fullPath = Path.Combine(newPath, fileName);
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    request.File.CopyTo(stream);
                }

                Publication publication = _mapper.Map<Publication>(request);
                publication.Id = Guid.NewGuid().ToString();
                publication.Image = fileName;

                if (request.Tags != null && request.Tags != string.Empty)
                {
                    string[] tagsArray = request.Tags.Split(",");

                    List<Tag> tags = new List<Tag>();

                    for (int i = 0; i < tagsArray.Length; i++)
                    {
                        string tagItem = tagsArray[i].Trim();

                        Tag tag = await _context.Tags.SingleOrDefaultAsync(x => x.Value == tagItem);

                        if (tag == null)
                        {
                            tag = new Tag
                            {
                                Id = Guid.NewGuid().ToString(),
                                Value = tagItem
                            };

                            _context.Tags.Add(tag);
                        }

                        tags.Add(tag);
                    }

                    foreach (Tag tag in tags)
                    {
                        TagToPublication tagToPublication = new TagToPublication
                        {
                            Id = Guid.NewGuid().ToString(),
                            PublicationId = publication.Id,
                            TagId = tag.Id
                        };

                        _context.TagsToPublications.Add(tagToPublication);
                    }
                }

                _context.Publications.Add(publication);

                await _context.SaveChangesAsync(cancellationToken);

                return publication.Id;
            }
        }
    }

}
