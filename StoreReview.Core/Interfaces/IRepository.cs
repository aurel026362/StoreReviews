using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreReview.Core.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(long id);
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdOrThrowNotFoundAsync(long id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(long id);
        void DeleteRange(IEnumerable<T> entities);
        IQueryable<T> Read();
        IQueryable<T> ReadSql(string query);
    }
}
