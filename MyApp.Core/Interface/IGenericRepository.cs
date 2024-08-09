namespace MyApp.Core.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T entity);
        ICollection<T> AddRange(ICollection<T> entities);
        void Delete(T entity);
        void DeleteRange(ICollection<T> entities);
        void Update(T entity);
        ICollection<T> UpdateRange(ICollection<T> entities);
    }
}
