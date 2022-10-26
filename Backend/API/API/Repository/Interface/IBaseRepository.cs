using System.Linq.Expressions;

namespace API.Repository.Interface
{
    public interface IBaseRepository<TModel>
    {
        IQueryable<TModel> GetById(Guid id);
        IQueryable<TModel> GetAll();
        IQueryable<TModel> FindByCondition(Expression<Func<TModel, bool>> expression);
        Task<TModel> Insert(TModel entity);
        Task<TModel> Update(TModel entity);
        Task Delete(TModel entity);
        Task Delete(Guid id);
        Task InsertMultiple(IList<TModel> entities);
        Task UpdateMultiple(IList<TModel> entities);
        Task DeleteMultiple(IList<TModel> entities);
        Task<bool> CheckExist(Guid id);
    }
}
