﻿using System.Collections.Generic;
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
        [HttpGet("ForType")]
        public IEnumerable<AchievementInstance> GetForType(int typeId, int userId)
        {
            return _instanceService.GetForType(typeId, userId);
        }

        [Authorize]
        [HttpPost]
        public Task<int> Create(AchievementInstance instance)
        {
            return _instanceService.Create(instance);
        }
        
    }
}