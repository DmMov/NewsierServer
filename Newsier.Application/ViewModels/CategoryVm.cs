using Newsier.Application.Mappings;
using Newsier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Application.ViewModels
{
    public sealed class CategoryVm : IMapFrom<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
