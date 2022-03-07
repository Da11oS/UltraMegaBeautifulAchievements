using System.Collections.Generic;
using System.Threading.Tasks;
using Achievements.Domain.Models;

namespace Sailora.Identity.Services
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEfRepository<T> where T: BaseEntity
    {
        /// <summary>
        /// Получить всё
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll();
        
        /// <summary>
        /// Получить по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetById(int id);
        
        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<long> Create(T entity);
        
        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task Delete(int id);
        
        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Update(T entity);
    }
}