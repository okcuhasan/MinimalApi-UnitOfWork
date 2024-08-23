namespace UnitOfWorks.Abstracts
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
