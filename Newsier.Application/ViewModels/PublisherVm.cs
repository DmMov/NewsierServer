using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System;

namespace Newsier.Application.ViewModels
{
    public sealed class PublisherVm : IMapFrom<Publisher>
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string CreatedAt { get; set; }
        public int Publications { get; set; }
        public int Comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Publisher, PublisherVm>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => $"{x.CreatedAt:MMMM dd}{(x.CreatedAt.Year == DateTime.UtcNow.Year ? "" : $"{x.CreatedAt:, yyyy}")}"))
                .ForMember(x => x.Publications, opt => opt.MapFrom(x => x.Publications.Count))
                .ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}
