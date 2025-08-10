namespace TTMS.Domain
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
