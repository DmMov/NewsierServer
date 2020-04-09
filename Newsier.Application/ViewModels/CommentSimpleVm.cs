using AutoMapper;
using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Application.ViewModels
{
    public sealed class CommentSimpleVm : IMapFrom<Comment>
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Publisher { get; set; }
        public string PublisherImage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentSimpleVm>()
                .ForMember(x => x.Publisher, opt => opt.MapFrom(x => $"{x.Publisher.Name} {x.Publisher.Surname}"))
                .ForMember(x => x.PublisherImage, opt => opt.MapFrom(x => x.Publisher.Image));
        }
    }
}
