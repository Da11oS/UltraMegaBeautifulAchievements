using System.Collections.Generic;

namespace Achievements.Domain.Models.Achievements
{
    public class AchievementValue : BaseEntity
    {
        public Column Column { get; set; }
        public string Value { get; set; }
    }
}