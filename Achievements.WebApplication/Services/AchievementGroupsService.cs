using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Services.Interfaces;

namespace Achievements.WebApplication.Services
{
    public class AchievementGroupsService : IAchievementGroupsService
    {
        private readonly IEfRepository<AchievementGroup> _groupRepository;

        public AchievementGroupsService(IEfRepository<AchievementGroup> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        
        public IEnumerable<AchievementGroup> GetGroups()
        {
            return _groupRepository.GetAll();
        }

        public async Task<int> CreateGroup(AchievementGroup group)
        {
            return await _groupRepository.Create(group);
        }
    }
}