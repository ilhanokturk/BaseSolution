using BaseSolution.Abstraction.Context.MongoContext;
using BaseSolution.Abstraction.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseSolution.Data.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoContext _mongoContext;
        protected readonly IMongoCollection<T> _dbCollection;

        public MongoRepository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _dbCollection = _mongoContext.GetCollection<T>(typeof(T).Name);
        }

        public void Create(T entity)
        {
            _dbCollection.InsertOne(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbCollection.InsertOneAsync(entity);
        }

        public void Delete(Guid id)
        {
            _dbCollection.DeleteOne(Builders<T>.Filter.Eq("_id", id));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }

        public void Dispose()
        {
            _mongoContext.Dispose();
            GC.SuppressFinalize(this);
            GC.SuppressFinalize(_mongoContext);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return _dbCollection.Find(expression).FirstOrDefault();
        }

        public T GetById(Guid id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", id);
            return _dbCollection.Find(filter).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", id);
            var result= await _dbCollection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetByListAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return await _dbCollection.Find(Builders<T>.Filter.Empty).ToListAsync();
            return await _dbCollection.Find(Builders<T>.Filter.Where(filter)).ToListAsync();
        }

        public List<T> ListByFilter(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return _dbCollection.Find(Builders<T>.Filter.Empty).ToList();
            return _dbCollection.Find(Builders<T>.Filter.Where(filter)).ToList();
        }

        public void Update(T entity, Guid id)
        {
            _dbCollection.ReplaceOne(Builders<T>.Filter.Eq("_id", id), entity);
        }

        public async Task UpdateAsync(T entity, Guid id)
        {
           await _dbCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
        }
    }
}
