using Newsier.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Interfaces
{
    public interface IEntitiesSearchService
    {
        Task<bool> ExistAsync<TEntity>(string id, CancellationToken cancellationToken) where TEntity : BaseEntity;
    }
}
