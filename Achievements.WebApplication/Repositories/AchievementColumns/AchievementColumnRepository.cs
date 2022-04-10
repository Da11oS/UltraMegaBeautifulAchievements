using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models.Achievements;
using Microsoft.EntityFrameworkCore;

namespace Achievements.WebApplication.Repositories.AchievementTypes
{
    public class AchievementColumnRepository : BaseRepository<Column>, IAchievementColumnRepository
    {
        public AchievementColumnRepository(ApplicationDbContext context) 
            : base(context) { }

        public IEnumerable<Column> GetByTypeId(int typeId)
        {
            return Context.AchievementTypes.FirstOrDefault(f => f.Id == typeId).Columns.ToArray();
        }
    }
}