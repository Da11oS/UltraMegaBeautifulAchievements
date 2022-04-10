using System;
using System.Collections.Generic;

namespace Achievements.Domain.Models.Achievements
{
    public class AchievementInstance : BaseEntity
    {
        public AchievementType AchievementType{ get; set; }
        public User User{ get; set; }
        public AchievementsStatus Status{ get; set; }
        public List<AchievementValue> Values { get; set; }
        public User Expert { get; set; }
        public DateTime CheckedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public enum AchievementsStatus : byte
    {
        Draft = 1,
        WaitForCheck = 2,
        Success = 3,
        Reject = 4,
    }
}