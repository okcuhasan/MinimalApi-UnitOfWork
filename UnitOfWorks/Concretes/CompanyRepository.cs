using UnitOfWorks.Abstracts;
using UnitOfWorks.Context;
using UnitOfWorks.Models;

namespace UnitOfWorks.Concretes
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly AppDbContext _appDbContext;
        public CompanyRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Company> Get(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
