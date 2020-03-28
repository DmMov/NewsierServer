using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;

namespace Newsier.Application.ViewModels
{
    public sealed class PublicationVm : IMapFrom<Publication>
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public long Views { get; set; }
        public string PublisherId { get; set; }
        public string Publisher { get; set; }
        public string CategoryId { get; set; }
        public string Category { get; set; }
        public string CreatedAt { get; set; }
        public string LastModifiedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Publication, PublicationVm>()
                .ForMember(x => x.Publisher, opt => opt.MapFrom(x => $"{x.Publisher.Name} {x.Publisher.Surname}"))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt.ToString("MM.dd.yyyy")))
                .ForMember(x => x.LastModifiedAt, opt => opt.MapFrom(x => x.LastModifiedAt.ToString("MM.dd.yyyy")));
        }
    }
}
