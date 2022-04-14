using System.Threading.Tasks;
using Achievements.Domain.Models;
using Achievements.WebApplication.Services.Interfaces;
using Achievements.WebApplication.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Achievements.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IStoredFileService _fileService;

        public FileController(IStoredFileService fileService)
        {
            _fileService = fileService;
        }
        
        [Authorize]
        [HttpPost("Load")]
        public async Task<IActionResult> Load(IFormFile file)
        {
            var user = (User)HttpContext.Items["User"];

            if (user == null) return BadRequest(new { message = "User not found" });
            
            var response = await _fileService.DoStoreFile(file, user);

            if (response == null)
                return BadRequest(new { message = "Failed to load file" });

            return Ok();
        }
        
        [Authorize]
        [HttpGet("Download")]
        public async Task<IActionResult> Download() // будет id Stored File
        {
            var user = (User)HttpContext.Items["User"];
            var fileDetails = await _fileService.GetStoredFile(user);
            
            if (fileDetails == null)
                return BadRequest(new { message = "Failed to download file" });
            
            return File(fileDetails.bytes, fileDetails.contentType, fileDetails.filePath);
        }
    }
}