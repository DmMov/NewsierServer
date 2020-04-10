using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Newsier.Application.ViewModels
{
    public sealed class DetailedPublicationVm : IMapFrom<Publication>
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public long Views { get; set; }
        public string PublisherId { get; set; }
        public string PublisherImage { get; set; }
        public string Publisher { get; set; }
        public string CategoryId { get; set; }
        public string Category { get; set; }
        public string CreatedAt { get; set; }
        public string LastModifiedAt { get; set; }
        public ICollection<TagVm> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            DateTimeFormatInfo dateTimeFormatInfo = CultureInfo.GetCultureInfo("uk-UA").DateTimeFormat;

            profile.CreateMap<Publication, DetailedPublicationVm>()
                .ForMember(x => x.PublisherImage, opt => opt.MapFrom(x => x.Publisher.Image))
                .ForMember(x => x.Publisher, opt => opt.MapFrom(x => $"{x.Publisher.Name} {x.Publisher.Surname}"))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt.ToString("dd MMMM, yyyy", dateTimeFormatInfo)))
                .ForMember(x => x.LastModifiedAt, opt => opt.MapFrom(x => x.LastModifiedAt.ToString("dd MMMM, yyyy", dateTimeFormatInfo)))
                .ForMember(
                    x => x.Tags,
                    opt => opt.MapFrom(
                        x => x.TagsToPublications
                            .Where(tp => tp.PublicationId == x.Id)
                            .Select(tp => tp.Tag)
                    )
                );
        }
    }
}
