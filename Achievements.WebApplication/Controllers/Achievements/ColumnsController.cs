using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Services.Interfaces;
using Achievements.WebApplication.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Achievements.WebApplication.Controllers.Achievements
{
    [ApiController]
    [Route("[controller]")]
    public class ColumnsController : ControllerBase
    {
        private readonly IAchievementColumnService _instanceColumnService; 
        public ColumnsController(IAchievementColumnService instanceColumnService)
        {
            _instanceColumnService = instanceColumnService;
        }
        
        [HttpGet]
        public IEnumerable<Column> GetAllTypes()
        {
            return _instanceColumnService.GetAllTypes();
        }
        
        [Authorize]
        [Route("{id:int?}")]
        public Column GetById(int id)
        {
            return _instanceColumnService.GetById(id);
        }
        
        [Authorize]
        [HttpGet("Type/{id:int?}")]
        public IEnumerable<Column> GetByTypeId(int typeId)
        {
            return _instanceColumnService.GetByTypeId(typeId);
        }

        [Authorize]
        [HttpPost]
        public Task<int> Create(Column column)
        {
            return _instanceColumnService.Create(column);
        }
    }
}