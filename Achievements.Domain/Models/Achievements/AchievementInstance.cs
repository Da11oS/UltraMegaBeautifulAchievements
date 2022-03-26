using System;
using System.Collections.Generic;

namespace Achievements.Domain.Models.Achievements
{
    public class AchievementInstance: BaseEntity
    {
        public AchievementType AchievementType{ get; set; }
        public User User{ get; set; }
        public string Status{ get; set; }
        public User Expert { get; set; } // позже - модель юзера / админа
        public DateTime CheckedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public enum Status
    {
        Draft = 1,
        WaitForCheck = 2,
        Success = 3,
        Reject = 4,
    }
}