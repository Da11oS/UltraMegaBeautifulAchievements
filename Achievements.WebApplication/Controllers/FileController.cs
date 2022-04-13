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
        public IActionResult Load(IFormFile file)
        {
            var user = (User)HttpContext.Items["User"];

            if (user == null) return BadRequest(new { message = "User not found" });
            
            var response = _fileService.DoStoreFile(file, user);

            if (response == null)
                return BadRequest(new { message = "Failed to load file" });

            return Ok();
        }
        
        [Authorize]
        [HttpGet("Download")]
        public IActionResult Download() // будет id Stored File
        {
            var user = (User)HttpContext.Items["User"];
            var file = _fileService.GetStoredFile(user);
            
            if (file == null)
                return BadRequest(new { message = $"Files did not found" });
            
            var filePath = $"{file.Directory}/{file.Identifier}.{file.Extension}";
            var fileType = $"{file.ContentType}";
            return PhysicalFile(filePath, fileType);
        }
    }
}