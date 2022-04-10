using Achievements.Domain.Models.Achievements;

namespace Achievements.Domain.ViewModels.AchievementTypes
{
    public record CreateAchievementTypeWithColumnsQuery(AchievementType Type, Column[] Columns);

    public record AchievementTypeView
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int AchievementGroup { get; init; }
    }
    
}