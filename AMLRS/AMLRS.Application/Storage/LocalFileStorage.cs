using AMLRS.Application.Interfaces.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AMLRS.Application.Storage
{
    public class LocalFileStorage : IFileStorage
    {
        private readonly string _rootPath;

        public LocalFileStorage(IConfiguration configuration)
        {
            _rootPath = configuration["Storage:RootPath"];
        }

        public async Task SaveAsync(string path, IFormFile file)
        {
            var fullPath = Path.Combine(_rootPath, path);

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }

}
