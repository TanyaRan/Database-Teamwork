namespace Bookstore.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Complete();

        void Dispose();
    }
}
