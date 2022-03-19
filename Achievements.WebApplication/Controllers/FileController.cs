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
        public IActionResult Login(IFormFile file, User user)
        {
            var response = _fileService.DoStoreFile(file, user);

            if (response == null)
                return BadRequest(new { message = "Failed to load file" });

            return Ok(response);
        }
    }
}