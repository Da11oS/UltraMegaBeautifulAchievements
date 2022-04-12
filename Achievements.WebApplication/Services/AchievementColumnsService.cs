using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Repositories.AchievementTypes;
using Achievements.WebApplication.Services.Interfaces;

namespace Achievements.WebApplication.Services
{
    public class AchievementColumnService : IAchievementColumnService
    {
        private readonly IAchievementColumnRepository _columnRepository;

        public AchievementColumnService(IAchievementColumnRepository columnRepository)
        {
            _columnRepository = columnRepository;
        }
        
        public IEnumerable<Column> GetAllTypes()
        {
            return _columnRepository.GetAll();
        }

        public Column GetById(int id)
        {
            return _columnRepository.GetById(id);
        }

        public IEnumerable<Column> GetByTypeId(int typeId)
        {
            return _columnRepository.GetByTypeId(typeId);
        }

        public Task<int> Create(Column column)
        {
            return _columnRepository.Create(column);
        }
    }
}