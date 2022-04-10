using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Repositories.AchievementTypes
{
    public interface IAchievementColumnRepository : IEfRepository<Column>
    {
        IEnumerable<Column> GetByTypeId(int typeId);
    }
}