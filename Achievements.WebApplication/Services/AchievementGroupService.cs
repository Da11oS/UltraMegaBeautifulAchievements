using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Achievements.WebApplication.Services
{
    public class AchievementGroupService : IAchievementGroupsService
    {
        private readonly IConfiguration _configuration;
        private readonly IEfRepository<AchievementGroup> _groupRepository;

        public AchievementGroupService(IConfiguration configuration, IEfRepository<AchievementGroup> groupRepository)
        {
            _configuration = configuration;
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