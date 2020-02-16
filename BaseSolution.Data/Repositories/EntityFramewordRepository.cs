using BaseSolution.Abstraction.Repository.Base;
using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseSolution.Data.Repositories
{
    public class EntityFramewordRepository<T> : IRepository<T> where T : class
    {
        DbContext _context;
        DbSet<T> _dbSet;

        public EntityFramewordRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
            GC.SuppressFinalize(_context);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).FirstOrDefault();
        }

        public T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetByListAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return await _dbSet.ToListAsync();
            return await _dbSet.Where(filter).ToListAsync();
        }

    

        public List<T> ListByFilter(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return _dbSet.ToList();
            return _dbSet.Where(filter).ToList();
        }

      

        public void Update(T entity, Guid id)
        {
            var updatedEntity=_context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
        }

        public async Task UpdateAsync(T entity, Guid id)
        {
            var updatedEntity = await Task.FromResult(_context.Entry(entity));
            updatedEntity.State = EntityState.Modified;
        }
    }
}
