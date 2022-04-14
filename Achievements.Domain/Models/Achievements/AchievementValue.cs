using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Achievements.Domain.Models.Achievements
{
    public class AchievementValue : BaseEntity
    {
        public Column Column { get; set; }
        public AchievementInstance AchievementInstance { get; set; }
        public string Value { get; set; }
    }
}