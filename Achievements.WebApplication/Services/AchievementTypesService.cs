using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Repositories.AchievementTypes;
using Achievements.WebApplication.Services.Interfaces;

namespace Achievements.WebApplication.Services
{
    public class AchievementTypesService : IAchievementTypesService
    {
        private readonly IAchievementTypesRepository _typeRepository;

        public AchievementTypesService(IAchievementTypesRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        
        public IEnumerable<AchievementType> GetAllTypes()
        {
            return _typeRepository.GetAll();
        }
        
        public AchievementType GetById(int id)
        {
            return _typeRepository.GetById(id);
        }

        public IEnumerable<AchievementType> GetTypesByGroupId(int id)
        {
            var group = new AchievementGroup {Id = id};
            return _typeRepository.GetTypesByGroup(group);
        }

        public async Task<int> Create(string name, AchievementGroup group)
        {
            var type = new AchievementType
            {
                Name = name,
                AchievementGroup = group
            };
            return await _typeRepository.Create(type);
        }
    }
}