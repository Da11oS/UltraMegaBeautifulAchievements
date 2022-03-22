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
        private readonly IUserService _userService;

        public FileController(IStoredFileService fileService, IUserService userService)
        {
            _fileService = fileService;
            _userService = userService;
        }
        
        [Authorize]
        [HttpPost("Load")]
        public IActionResult Load(IFormFile file, [FromForm]int id)
        {
            var user = _userService.GetById(id);

            if (user == null) return BadRequest(new { message = "User not found" });
            
            var response = _fileService.DoStoreFile(file, user);

            if (response == null)
                return BadRequest(new { message = "Failed to load file" });

            return Ok(response);
        }
    }
}