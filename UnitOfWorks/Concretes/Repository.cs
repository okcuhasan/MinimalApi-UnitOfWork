using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using UnitOfWorks.Abstracts;
using UnitOfWorks.Context;
using UnitOfWorks.Models;

namespace UnitOfWorks.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Entity => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry ee = await Entity.AddAsync(entity);
            return ee.State == EntityState.Added;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

        public bool Delete(T entity)
        {
            EntityEntry ee = Entity.Remove(entity);
            return ee.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            T entity = await Entity.FirstOrDefaultAsync(x => x.Id == id);
            return Delete(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            Entity.RemoveRange(entities);
        }

        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entity.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetFirstAsync()
        {
            return await Entity.FirstOrDefaultAsync();
        }

        public async Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await Entity.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Entity.Where(predicate);
        }

        public bool Update(T entity)
        {
            EntityEntry ee = Entity.Update(entity);
            return ee.State == EntityState.Deleted;
        }

        public void UpdateRange(List<T> entities)
        {
            Entity.UpdateRange(entities);
        }
    }
}
