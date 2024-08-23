using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnitOfWorks.Models;

namespace UnitOfWorks.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Entity { get; }
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        bool Update(T entity);
        void UpdateRange(List<T> entities);
        bool Delete(T entity);
        void DeleteRange(List<T> entities);
        Task<bool> DeleteByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstAsync();
    }
}
