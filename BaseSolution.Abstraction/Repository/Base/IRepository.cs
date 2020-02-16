using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseSolution.Abstraction.Repository.Base
{
    public interface IRepository<T>:IDisposable where T : class
    {
        /// <summary>
        /// Create new Record in database
        /// </summary>
        /// <param name="entity">T</param>
        void Create(T entity);

        /// <summary>
        /// Update record in database
        /// </summary>
        /// <param name="entity">T</param>
        /// <param name="id">entity id</param>
        void Update(T entity, Guid id);
        //PageResult<Category> GetListPaging(int currentPage=1, int pageSize=10);

        /// <summary>
        /// Delete from in database
        /// </summary>
        /// <param name="id">entity id</param>
        void Delete(Guid id);

        /// <summary>
        /// Listing to datas from database
        /// </summary>
        /// <param name="filter">expression filter</param>
        /// <returns>List<T></returns>
        List<T> ListByFilter(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// only 1 record from database
        /// </summary>
        /// <param name="expression">expression filter</param>
        /// <returns>entity or null</returns>
        T GetBy(Expression<Func<T, bool>> expression);

        /// <summary>
        /// only 1 record from database
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>entity or null</returns>
        T GetById(Guid id);


        /// <summary>
        /// Create new record in database with async
        /// </summary>
        /// <param name="entity">T</param>
        /// <returns></returns>
        Task CreateAsync(T entity);

        /// <summary>
        /// Update new record in database with async
        /// </summary>
        /// <param name="entity">T</param>
        /// <param name="id">entity id</param>
        /// <returns></returns>
        Task UpdateAsync(T entity, Guid id);

        /// <summary>
        /// Delete record in database with async
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Listing to datas from database with async
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <returns>List<T></returns>
        Task<List<T>> GetByListAsync(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// only 1 record from database with async
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns>T or null</returns>
        Task<T> GetByIdAsync(Guid id);

        
    }
}
