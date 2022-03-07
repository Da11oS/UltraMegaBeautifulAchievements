using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Achievements.UI.Services
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