using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievements.Database;
using Achievements.Domain.Models;

namespace Achievements.WebApplication.Repositories
{
    public class BaseRepository<T>: IEfRepository<T> where T: BaseEntity
    {
        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> Create(T entity)
        {
            var result = await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Delete(int id)
        {
            var result = GetById(id);
            Context.Set<T>().Remove(result);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
             Context.Update(entity);
             await Context.SaveChangesAsync();
        }
    }
}