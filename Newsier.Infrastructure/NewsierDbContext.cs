using Microsoft.EntityFrameworkCore;
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

        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagToPublication> TagsToPublications { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid().ToString();
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.Now;
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
