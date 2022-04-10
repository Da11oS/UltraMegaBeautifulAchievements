using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Repositories.AchievementTypes;
using Achievements.WebApplication.Services.Interfaces;

namespace Achievements.WebApplication.Services
{
    public class AchievementInstanceService: IAchievementInstanceService
    {
        private readonly IAchievementInstanceRepository _achievementRepository;

        public AchievementInstanceService(IAchievementInstanceRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }
        
        public IEnumerable<AchievementInstance> GetAllTypes()
        {
            return _achievementRepository.GetAll();
        }

        public AchievementInstance GetById(int id)
        {
            return _achievementRepository.GetById(id);
        }

        public IEnumerable<AchievementInstance> GetForType(int typeId, int userId)
        {
            return _achievementRepository.GetForType(typeId, userId);
        }

        public Task<int> Create(AchievementInstance instance)
        {
            return _achievementRepository.Create(instance);
        }
    }
}