using System.Runtime.InteropServices;

namespace Achievements.Domain.Models.Achievements
{
    /// <summary>
    /// Свойства столбцов
    /// </summary>
    public class Column : BaseEntity
    {
        public DataType DataType { get; set; }
        public string Label { get; set; }
        public AchievementType AchievementType { get; set; }
    }

}