using System.Linq.Expressions;

namespace API.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetById(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task InsertMultiple(IList<T> entity);
        Task UpdateMultiple(IList<T> entity);
        Task DeleteMultiple(IList<T> entity);
    }
}
