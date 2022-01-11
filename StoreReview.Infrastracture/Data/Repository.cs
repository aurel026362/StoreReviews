using Microsoft.EntityFrameworkCore;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReivew.Infrastracture.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly StoreReviewDbContext _dbContext;
        //private readonly ICurrentUser currentUser;

        public Repository(StoreReviewDbContext dbContext)
        {
            _dbContext = dbContext;
            //this.currentUser = currentUser;
        }

        public T GetById(long id) =>
            _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);

        public async Task<T> GetByIdAsync(long id) =>
            await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);

        public async Task<T> GetByIdOrThrowNotFoundAsync(long id) =>
            await GetByIdAsync(id)
            ?? throw new DllNotFoundException($"Could not find an entity with id: {id}");

        public virtual IQueryable<T> Read() =>
            _dbContext.Set<T>().OrderBy(x => x.Id);

        public IQueryable<T> ReadSql(string query) =>
            _dbContext.Set<T>().FromSqlRaw(query);

        public List<T> GetAll() =>
            _dbContext.Set<T>().ToList();

        public async Task<List<T>> GetAllAsync() =>
            await _dbContext.Set<T>().ToListAsync();

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            T entity = await GetByIdOrThrowNotFoundAsync(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            _dbContext.SaveChanges();

            return entities;
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            var list = entities.ToList();
            _dbContext.Set<T>().AddRange(list);
            _dbContext.SaveChanges();

            return list;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

    }
}