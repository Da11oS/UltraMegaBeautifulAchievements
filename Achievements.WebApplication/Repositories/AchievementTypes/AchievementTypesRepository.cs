using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models.Achievements;

namespace Achievements.WebApplication.Repositories.AchievementTypes
{
    public class AchievementTypesRepository : BaseRepository<AchievementType>, IAchievementTypesRepository
    {
        public AchievementTypesRepository(ApplicationDbContext context) 
            : base(context) { }

        public IEnumerable<AchievementType> GetTypesByGroup(AchievementGroup group)
        {
            return Context.Set<AchievementType>().Where(type => type.AchievementGroup == group);
        }
    }
}