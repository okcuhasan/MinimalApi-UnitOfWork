using UnitOfWorks.Models;

namespace UnitOfWorks.Abstracts
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> Get(int id);
    }
}
