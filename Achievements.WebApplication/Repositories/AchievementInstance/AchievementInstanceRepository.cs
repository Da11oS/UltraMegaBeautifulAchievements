using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models.Achievements;
using Microsoft.EntityFrameworkCore;

namespace Achievements.WebApplication.Repositories.AchievementTypes
{
    public class AchievementInstanceRepository : BaseRepository<AchievementInstance>, IAchievementInstanceRepository
    {
        public AchievementInstanceRepository(ApplicationDbContext context) 
            : base(context) { }

        public IEnumerable<AchievementInstance> GetForType(int typeId, int userId)
        {
            return Context.AchievementInstances
                .Where(f => f.AchievementType.Id == typeId && f.User.Id == userId).AsEnumerable();
        }
        public AchievementInstance GetEmptyInstance(int typeId)
        {
            var achievementType = Context.AchievementTypes.FirstOrDefault(f => f.Id == typeId);
            
            var instance = new AchievementInstance
            {
                AchievementType = achievementType,
            };
            
            var values = Context.Columns.Where(w => w.AchievementType.Id == achievementType.Id).Select(s => new AchievementValue()
            {
                Column = s,
                AchievementInstance = instance,
            });
            
            instance.Values = values.ToList();
            return instance;
        }
    }
}