using Microsoft.AspNetCore.Http;

namespace AMLRS.Application.Interfaces.Storage
{
    public interface IFileStorage
    {
        Task SaveAsync(string path, IFormFile file);
    }

}
