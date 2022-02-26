using Microsoft.EntityFrameworkCore;

namespace Achievements.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        // DbSet'ы моделей будут тут
    }
}