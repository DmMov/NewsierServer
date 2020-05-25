using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newsier.Application.Base;
using Newsier.Application.Interfaces;
using Newsier.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetAllCategories
{
    public sealed class GetAllCategoriesQuery : IRequest<List<CategoryVm>>
    {
        public sealed class Handler : HandlerBase, IRequestHandler<GetAllCategoriesQuery, List<CategoryVm>>
        {
            public Handler(INewsierContext context, IMapper mapper) : base(context, mapper) { }

            public async Task<List<CategoryVm>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                List<CategoryVm> categories = await _context.Categories
                    .OrderByDescending(x => x.Name)
                    .ProjectTo<CategoryVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return categories;
            }
        }
    }

}
