using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IStoredFileService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task StoreFile(IFormFile file);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task GetFile();
        
        
    }
}