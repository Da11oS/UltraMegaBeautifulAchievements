using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IAchievementTypesService
    {
        IEnumerable<AchievementType> GetAllTypes();
        AchievementType GetById(int id);
        IEnumerable<AchievementType> GetTypesByGroupId(int id);
        Task<int> Create(string name, AchievementGroup group);
        Task Create(AchievementType type, Column[] columns);
    }
}