using MyApp.Core.Interface;
using MyApp.Core.IRepositories;
using MyApp.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContex _dbContext;

        public UnitOfWork(AppDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        public IUserRepository Users
        {
            get
            {
                if (Users is null)
                {
                    return new UserRepository(_dbContext);
                }
                return Users;
            }
        }

        public int Save()
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                int result = 0;
                try
                {
                    result = _dbContext.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return result;
                }
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
