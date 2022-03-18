using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models;

namespace Achievements.WebApplication.Repositories
{
    public class BaseRepository<T>: IEfRepository<T> where T: BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> Create(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Delete(int id)
        {
            var result = GetById(id);
            _context.Set<T>().Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
             _context.Update(entity);
             await _context.SaveChangesAsync();
        }
    }
}