using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Achievements.Domain.Models.Achievements
{
    public class AchievementType : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public AchievementGroup AchievementGroup { get; set; }
        public List<Column> Columns { get; set; }
    }
}