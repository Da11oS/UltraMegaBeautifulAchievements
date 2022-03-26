using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Services;
using Achievements.WebApplication.Services.Interfaces;
using Achievements.WebApplication.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Achievements.WebApplication.Controllers.Achievements
{
    [ApiController]
    [Route("Achievements/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IAchievementGroupsService _groupsService;

        public GroupsController(IAchievementGroupsService groupsService)
        {
            _groupsService = groupsService;
        }
        
        [Authorize]
        [HttpGet]
        public IEnumerable<AchievementGroup> GetGroups()
        {
            return _groupsService.GetGroups();
        }
        
        [Authorize]
        [HttpPost("Create")]
        public async Task<int> Create(AchievementGroup group)
        {
            return await _groupsService.CreateGroup(group);
        }
    }
}