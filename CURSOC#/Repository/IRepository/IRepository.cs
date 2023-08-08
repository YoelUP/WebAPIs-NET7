using System.Linq.Expressions;

namespace CURSOC_.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);

        Task<List<T>> ObtainAll(Expression<Func<T, bool>>? filtro = null);

        Task<T> Obtain(Expression<Func<T, bool>> filtro = null,  bool tracked = true);

        Task Delete(T entity);

        Task Save();

    }
}
