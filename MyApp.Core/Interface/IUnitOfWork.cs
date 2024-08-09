using MyApp.Core.IRepositories;

namespace MyApp.Core.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        int Save();
    }
}
