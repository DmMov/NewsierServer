using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Newsier.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> AddFileToDirectoryAsync(IFormFile file, string directory);
        Task<bool> RemoveFileFromDirectoryAsync(string fileName, string directory);
    }
}
