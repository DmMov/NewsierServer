using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System;

namespace Newsier.Application.ViewModels
{
    public sealed class CommentVm : IMapFrom<Comment>
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string PublisherId { get; set; }
        public string Publisher { get; set; }
        public string PublisherImage { get; set; }
        public bool CanDelete { get; set; }
        public string CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentVm>()
                .ForMember(x => x.Publisher, opt => opt.MapFrom(x => $"{x.Publisher.Name} {x.Publisher.Surname}"))
                .ForMember(x => x.PublisherImage, opt => opt.MapFrom(x => x.Publisher.Image))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x =>
                    $"{x.CreatedAt:MMMM dd}{(x.CreatedAt.Year == DateTime.UtcNow.Year ? "" : $"{x.CreatedAt:, yyyy}")}, at {x.CreatedAt:hh:mm}")
                );
        }
    }
}
