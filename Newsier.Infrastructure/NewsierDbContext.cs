using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newsier.Application.Interfaces;
using Newsier.Domain.Entities;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Newsier.Infrastructure
{
    public class NewsierDbContext : DbContext, INewsierDbContext
    {
        private readonly IDateTime _dateTime;

        public NewsierDbContext(
            DbContextOptions<NewsierDbContext> options,
            IDateTime dateTime
        ) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagToPublication> TagsToPublications { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid().ToString();
                        entry.Entity.CreatedAt = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
