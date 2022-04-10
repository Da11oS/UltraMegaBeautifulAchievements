using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;
using Achievements.WebApplication.Repositories;
using Achievements.WebApplication.Services.Interfaces;

namespace Achievements.WebApplication.Services
{
    public class AchievementGroupsService : IAchievementGroupsService
    {
        private readonly IEfRepository<AchievementGroup> _groupRepository;
        private readonly IAchievementTypesService _achievements;

        public AchievementGroupsService(IEfRepository<AchievementGroup> groupRepository, IAchievementTypesService achievements)
        {
            _groupRepository = groupRepository;
            _achievements = achievements;
        }
        
        public IEnumerable<AchievementGroup> GetGroups()
        {
            return _groupRepository.GetAll();
        }
        
        public IEnumerable<GroupWithTypes> GetGroupsWithTypes()
        {
            return _groupRepository.GetAll().Select(s => new GroupWithTypes
            {
                Id = s.Id,
                Name = s.Name,
                Types = _achievements.GetTypesByGroupId(s.Id)
            });
        }
        public AchievementGroup GetGroupById(int id)
        {
            return _groupRepository.GetById(id);
        }

        public async Task<int> CreateGroup(AchievementGroup group)
        {
            return await _groupRepository.Create(group);
        }
    }

    public record GroupWithTypes
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public IEnumerable<AchievementType> Types { get; init; }
    }
}