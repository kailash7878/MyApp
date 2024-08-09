using MyApp.Core.Interface;
using MyApp.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContex _dbContext;
        protected GenericRepository(AppDbContex context)
        {
            _dbContext = context;
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> AddRange(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> UpdateRange(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
