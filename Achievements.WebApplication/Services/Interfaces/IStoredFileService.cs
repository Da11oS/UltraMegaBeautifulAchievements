using System.Threading.Tasks;
using Achievements.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IStoredFileService
    {
        public Task<bool> DoStoreFile(IFormFile file, User user);
        
        public Task<StoredFile> GetFile();
    }
}