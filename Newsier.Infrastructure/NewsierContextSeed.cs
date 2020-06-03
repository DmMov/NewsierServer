using Newsier.Application.Helpers;
using Newsier.Domain.Entities;
using Newsier.Infrastructure.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Newsier.Infrastructure
{
    public static class NewsierContextSeed
    {
        public static async Task SeedAsync(NewsierContext context)
        {
            if (!context.Publishers.Any())
                context.Publishers.Add(
                    new Publisher
                    {
                        Id = "publisher1",
                        Name = "володимир",
                        Surname = "милисюк",
                        Email = "volodymyr@newsier.com",
                        Password = Convert.ToBase64String(new PasswordHash("admin").ToArray()),
                        Role = "admin",
                        CreatedAt = DateTime.UtcNow,
                        Image = "volodymyr.png"
                    }
                );

            if (!context.Categories.Any())
                context.Categories.AddRange(await SeedHelper.SeedDataAsync<Category>("categories.json"));

            if (!context.Publications.Any())
                context.Publications.AddRange(await SeedHelper.SeedDataAsync<Publication>("publications.json"));

            if (!context.Tags.Any())
                context.Tags.AddRange(await SeedHelper.SeedDataAsync<Tag>("tags.json"));

            if (!context.TagsToPublications.Any())
                context.TagsToPublications.AddRange(await SeedHelper.SeedDataAsync<TagToPublication>("tags-to-publications.json"));

            await context.SaveChangesAsync();
        }
    }
}
