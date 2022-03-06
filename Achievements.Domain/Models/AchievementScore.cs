using System;

namespace Achievements.Domain.Models
{
    /// <summary>
    /// Модель оцененной работы
    /// </summary>
    public class AchievementScore : BaseEntity
    {
        public StoredFile StoredFile { get; set; }
        public int ExpertId { get; set; } // позже - модель юзера / админа
        public DateTime Timestamp { get; set; }
    }
}