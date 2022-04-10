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
    }
}