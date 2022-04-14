using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Repositories.AchievementTypes
{
    public interface IAchievementInstanceRepository : IEfRepository<AchievementInstance>
    {
        IEnumerable<AchievementInstance> GetForType(int typeId, int userId);
        AchievementInstance GetEmptyInstance(int typeId);
        Task<int> CreateWithNewColumns(AchievementInstance instance);
    }
}