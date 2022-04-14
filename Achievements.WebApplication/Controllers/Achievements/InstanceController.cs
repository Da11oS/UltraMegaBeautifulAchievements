using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database.Migrations;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Services.Interfaces;
using Achievements.WebApplication.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Achievements.WebApplication.Controllers.Achievements
{
    [ApiController]
    [Route("[controller]")]
    public class InstancesController : ControllerBase
    {
        private readonly IAchievementInstanceService _instanceService; 
        public InstancesController(IAchievementInstanceService instanceService)
        {
            _instanceService = instanceService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<AchievementInstance> GetAllTypes()
        {
            return _instanceService.GetAllTypes();
        }
        
        [Authorize]
        [Route("{id:int?}")]
        public AchievementInstance GetTypesById(int id)
        {
            return _instanceService.GetById(id);
        }
        
        
        [Authorize]
        [HttpGet("ForType/{typeId:int?}/{userId:int?}")]
        public IEnumerable<AchievementInstance> GetForType(int typeId, int userId)
        {
            return _instanceService.GetForType(typeId, userId);
        }
        [Authorize]
        [HttpGet("Empty/{typeId:int?}")]
        public AchievementInstance GetEmptyInstance(int typeId)
        {
            return _instanceService.GetEmptyInstance(typeId);
        }
        [Authorize]
        [HttpPost]
        public Task<int> Create(AchievementInstance instance)
        {
            return _instanceService.CreateWithNewColumns(instance);
        }
        
    }
}