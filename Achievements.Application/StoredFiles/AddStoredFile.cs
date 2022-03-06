using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models;

namespace Achievements.Application.StoredFiles
{
    public class AddStoredFile
    {
        private readonly ApplicationDbContext _context;
        
        public AddStoredFile(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task Do(string name, int userId)
        {
            // TODO: Добавить файл в папку
            
            _context.StoredFiles.Add(new StoredFile
            {
                Name = name,
                IdUser = userId
            });
            
            await _context.SaveChangesAsync();
        }
    }
}