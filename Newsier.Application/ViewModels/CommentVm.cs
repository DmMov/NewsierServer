using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System.Globalization;

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
        public string LastModifiedAt { get; set; }

        public void Mapping(Profile profile)
        {
            DateTimeFormatInfo dateTimeFormatInfo = CultureInfo.GetCultureInfo("uk-UA").DateTimeFormat;

            profile.CreateMap<Comment, CommentVm>()
                .ForMember(x => x.Publisher, opt => opt.MapFrom(x => $"{x.Publisher.Name} {x.Publisher.Surname}"))
                .ForMember(x => x.PublisherImage, opt => opt.MapFrom(x => x.Publisher.Image))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt.ToString("dd MMMM, yyyy, hh:mm", dateTimeFormatInfo)))
                .ForMember(x => x.LastModifiedAt, opt => opt.MapFrom(x => x.LastModifiedAt.ToString("dd MMMM, yyyy, hh:mm", dateTimeFormatInfo)));
        }
    }
}
