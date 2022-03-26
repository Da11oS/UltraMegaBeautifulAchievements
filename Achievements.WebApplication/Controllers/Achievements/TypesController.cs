using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.Domain.ViewModels;
using Achievements.WebApplication.Services.Interfaces;
using Achievements.WebApplication.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Achievements.WebApplication.Controllers.Achievements
{
    [ApiController]
    [Route("[controller]")]
    public class TypesController : ControllerBase
    {
        private readonly IAchievementTypesService _typesService;
        private readonly IAchievementGroupsService _groupsService;

        public TypesController(IAchievementTypesService typesService, IAchievementGroupsService groupsService)
        {
            _typesService = typesService;
            _groupsService = groupsService;
        }

        [Authorize]
        public IEnumerable<AchievementType> GetAllTypes()
        {
            return _typesService.GetAllTypes();
        }
        
        [Authorize]
        [Route("{id:int?}")]
        public AchievementType GetTypesById(int id)
        {
            return _typesService.GetById(id);
        }
        
        [Authorize]
        [HttpGet("Group/{id:int?}")]
        public IEnumerable<AchievementType> GetTypesByGroupId(int id)
        {
            return _typesService.GetTypesByGroupId(id);
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<int> Create(string name, int groupId)
        {
            var group = _groupsService.GetGroupById(groupId);
            return await _typesService.Create(name, group);
        }
    }
}