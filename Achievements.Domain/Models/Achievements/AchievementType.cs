namespace Achievements.Domain.Models.Achievements
{
    public class AchievementType : BaseEntity
    {
        public string Name { get; set; }
        public AchievementGroup AchievementGroup { get; set; }
    }
}