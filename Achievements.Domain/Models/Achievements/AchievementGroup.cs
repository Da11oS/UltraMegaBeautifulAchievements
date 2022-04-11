using System.Collections.Generic;

namespace Achievements.Domain.Models.Achievements
{
    public class AchievementGroup : BaseEntity
    {
        public string Name { get; init; }
        public List<AchievementType> Types { get; init; }
    }
}