using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System.Globalization;

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
        public uint Publications { get; set; }
        public uint Comments { get; set; }

        public void Mapping(Profile profile)
        {
            DateTimeFormatInfo dateTimeFormatInfo = CultureInfo.GetCultureInfo("uk-UA").DateTimeFormat;

            profile.CreateMap<Publisher, PublisherVm>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt.ToString("dd MMMM, yyyy", dateTimeFormatInfo)))
                .ForMember(x => x.Publications, opt => opt.MapFrom(x => (uint)x.Publications.Count))
                .ForMember(x => x.Comments, opt => opt.MapFrom(x => (uint)x.Comments.Count));
        }
    }
}
