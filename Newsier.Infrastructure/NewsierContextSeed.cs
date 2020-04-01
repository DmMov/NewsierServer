﻿using Newsier.Application.Helpers;
using Newsier.Domain.Entities;
using Newsier.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsier.Infrastructure
{
    public static class NewsierContextSeed
    {
        public static async Task SeedAsync(NewsierContext context)
        {
            if (!context.Publishers.Any())
                context.Publishers.AddRange(
                    new Publisher
                    {
                        Id = "publisher-one",
                        Name = "Volodymyr",
                        Surname = "Mylysiuk",
                        Email = "admin@newsier.com",
                        Password = Convert.ToBase64String(new PasswordHash("admin").ToArray()),
                        Role = "admin",
                        CreatedAt = DateTime.Now,
                        Image = "default-user.png"
                    },
                    new Publisher
                    {
                        Id = "publisher-two",
                        Name = "Dmitriy",
                        Surname = "Movchaniuk",
                        Email = "publisher@newsier.com",
                        Password = Convert.ToBase64String(new PasswordHash("publisher").ToArray()),
                        Role = "publisher",
                        CreatedAt = DateTime.Now,
                        Image = "default-user.png"
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

            if (!context.Comments.Any())
                context.Comments.AddRange(await SeedHelper.SeedDataAsync<Comment>("comments.json"));

            await context.SaveChangesAsync();
        }
    }
}