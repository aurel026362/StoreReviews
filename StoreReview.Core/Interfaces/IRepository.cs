using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreReview.Core.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(long id);
        T GetByIdOrThrowNotFound(long id);
        List<T> GetAll();
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(long id);
        void DeleteRange(IEnumerable<T> entities);
        IQueryable<T> Read();
        IQueryable<T> ReadSql(string query);
    }
}
