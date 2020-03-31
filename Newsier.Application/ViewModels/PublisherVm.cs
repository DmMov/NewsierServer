﻿using Newsier.Application.Mappings;
using Newsier.Domain.Entities;

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
    }
}