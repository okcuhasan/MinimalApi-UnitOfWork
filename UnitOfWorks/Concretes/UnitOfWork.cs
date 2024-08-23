using UnitOfWorks.Abstracts;
using UnitOfWorks.Context;

namespace UnitOfWorks.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
