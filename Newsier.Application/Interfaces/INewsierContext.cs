using Microsoft.EntityFrameworkCore;
using Newsier.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Application.Interfaces
{
    public interface INewsierContext
    {
        DbSet<Publisher> Publishers { get; set; }
        DbSet<Publication> Publications { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<TagToPublication> TagsToPublications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
