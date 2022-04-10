using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Repositories.AchievementTypes
{
    public interface IAchievementTypesRepository : IEfRepository<AchievementType>
    {
        IEnumerable<AchievementType> GetTypesByGroup(AchievementGroup group);
        Task Create(AchievementType type, Column[] columns);
    }
}