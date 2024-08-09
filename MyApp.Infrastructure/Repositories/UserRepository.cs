using MyApp.Core.IRepositories;
using MyApp.Data;
using MyApp.Data.Models;

namespace MyApp.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContex dbContext) : base(dbContext) { }
    }
}
