using AutoMapper;
using MediatR;
using Newsier.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsier.Application.Base
{
    public class QueryHandlerBase
    {
        protected readonly INewsierContext _context;
        protected readonly IMapper _mapper;

        public QueryHandlerBase(INewsierContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
