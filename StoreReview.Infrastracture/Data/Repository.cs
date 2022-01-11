using Microsoft.EntityFrameworkCore;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public T GetById(long id)
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public T GetByIdOrThrowNotFound(long id)
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public virtual IQueryable<T> Read() => _dbContext.Set<T>().OrderBy(x => x.Id);

        public IQueryable<T> ReadSql(string query)
        {
            return _dbContext.Set<T>().FromSqlRaw(query);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(long id)
        {
            T entity = GetByIdOrThrowNotFound(id);
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