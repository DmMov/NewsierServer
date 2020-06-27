using Newsier.Application.Helpers;
using Newsier.Domain.Entities;
using Newsier.Infrastructure.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Newsier.Infrastructure
{
    public sealed class NewsierContextSeed
    {
        public async Task SeedAsync(NewsierContext context)
        {
            SeedHelper seedHelper = new SeedHelper();

            if (!context.Publishers.Any())
                context.Publishers.Add(
                    new Publisher
                    {
                        Id = "pr-1",
                        Name = "dmitriy",
                        Surname = "movchaniuk",
                        Email = "dmitriy@newsier.com",
                        Password = Convert.ToBase64String(new PasswordHash("dmitriyAdmin").ToArray()),
                        Role = "admin",
                        CreatedAt = DateTime.UtcNow,
                        Image = "dmitriy.jpg"
                    }
                );

            if (!context.Categories.Any())
                context.Categories.AddRange(await seedHelper.SeedDataAsync<Category>("categories.json"));

            if (!context.Publications.Any())
                context.Publications.AddRange(await seedHelper.SeedDataAsync<Publication>("publications.json"));

            if (!context.Tags.Any())
                context.Tags.AddRange(await seedHelper.SeedDataAsync<Tag>("tags.json"));

            if (!context.TagsToPublications.Any())
                context.TagsToPublications.AddRange(await seedHelper.SeedDataAsync<TagToPublication>("tags-to-publications.json"));

            await context.SaveChangesAsync();
        }
    }
}
