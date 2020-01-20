using TestProject.Common;

namespace TestProject.DataAccess
{
    public interface IUnitOfWork
    {
        GenericRepository<Person> PersonRepository { get; }

        void Dispose();
        void EnsureDataStoreAsync();
        void Save();
    }
}