using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Queries.GetAllValues
{
    public sealed class GetAllValuesQuery : IRequest<string[]>
    {
        public sealed class Handler : IRequestHandler<GetAllValuesQuery, string[]>
        {
            public Task<string[]> Handle(GetAllValuesQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new string[] { "value 1", "value 2" });
            }
        }
    }
}
