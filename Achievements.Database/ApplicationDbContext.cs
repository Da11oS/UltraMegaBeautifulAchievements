using Achievements.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Achievements.Database
{
    /// <summary>
    /// Контекст соединения с БД
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        public DbSet<StoredFile> StoredFiles { get; set; }
        public DbSet<AchievementScore> AchievementScores { get; set; }


        // Уставновка ef tool'а
        // cmd > dotnet tool install --global dotnet-ef
        
        // Создание миграций
        // cmd> cd ./Achievements.Database
        // cmd> dotnet ef --startup-project ../Achievements.UI migrations add init
        // cmd> dotnet ef --startup-project ../Achievements.UI database update
    }
}