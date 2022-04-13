using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IAchievementInstanceService
    {
        IEnumerable<AchievementInstance> GetAllTypes();
        AchievementInstance GetById(int id);
        IEnumerable<AchievementInstance> GetForType(int typeId, int userId);
        Task<int> Create(AchievementInstance instance);
        AchievementInstance GetEmptyInstance(int typeId);
    }
}