using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IAchievementGroupsService
    {
        IEnumerable<AchievementGroup> GetGroups();
        Task<int> CreateGroup(AchievementGroup group);
    }
}