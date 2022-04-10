using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IAchievementGroupsService
    {
        IEnumerable<AchievementGroup> GetGroups();
        AchievementGroup GetGroupById(int id);
        Task<int> CreateGroup(AchievementGroup group);
        IEnumerable<GroupWithTypes> GetGroupsWithTypes();
    }
}