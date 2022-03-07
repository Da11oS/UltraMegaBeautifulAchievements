using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Sailora.Identity.Services;

namespace Achievements.Application.Repositories
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

        public async Task<T> GetById(int id)
        {
            //todo: need to add logger
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> Create(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Delete(int id)
        {
            var result = await GetById(id);
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