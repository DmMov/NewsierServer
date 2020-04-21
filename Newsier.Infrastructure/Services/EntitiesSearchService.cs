using Microsoft.EntityFrameworkCore;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Infrastructure.Services
{
    public sealed class EntitiesSearchService : IEntitiesSearchService
    {
        private readonly INewsierContext _context;

        public EntitiesSearchService(INewsierContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistAsync<TEntity>(string id, CancellationToken cancellationToken) where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>()
               .AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
