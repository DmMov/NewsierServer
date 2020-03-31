using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Newsier.Infrastructure.Helpers
{
    public static class SeedHelper
    {
        public static async Task<List<TEntity>> SeedDataAsync<TEntity>(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Assets/Json";
            string fullPath = Path.Combine(currentDirectory, path, fileName);

            List<TEntity> result = new List<TEntity>();

            using (StreamReader reader = new StreamReader(fullPath))
            {
                string json = await reader.ReadToEndAsync();
                result = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }

            return result;
        }
    }
}
