using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Application.ViewModels
{
    public sealed class TagVm : IMapFrom<Tag>
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
