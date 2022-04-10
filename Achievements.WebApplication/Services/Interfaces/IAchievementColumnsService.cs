using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Services.Interfaces
{
    public interface IAchievementColumnService
    {
        IEnumerable<Column> GetAllTypes();
        Column GetById(int id);
        IEnumerable<Column> GetByTypeId(int typeId);
        Task<int> Create(Column column);
    }
}