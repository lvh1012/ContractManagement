using API.DataContext;
using API.Model;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repository
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        private readonly ApplicationDataContext _applicationDataContext;

        protected BaseRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }

        public async Task Insert(TModel entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = Guid.Empty;
            await _applicationDataContext.AddAsync(entity);
            await _applicationDataContext.SaveChangesAsync();
        }

        public async Task InsertMultiple(IList<TModel> entities)
        {
            foreach (var item in entities)
            {
                item.CreatedOn = DateTime.Now;
                item.CreatedBy = Guid.Empty;
            }
            await _applicationDataContext.AddRangeAsync(entities);
            await _applicationDataContext.SaveChangesAsync();
        }

        public async Task Delete(TModel entity)
        {
            entity.IsDeleted = true;
            await Update(entity);
        }

        public async Task DeleteMultiple(IList<TModel> entities)
        {
            foreach (var item in entities)
            {
                item.IsDeleted = true;
            }
            await UpdateMultiple(entities);
        }

        public IQueryable<TModel> FindByCondition(Expression<Func<TModel, bool>> expression)
        {
            return _applicationDataContext.Set<TModel>().Where(expression).Where(r => !r.IsDeleted).AsNoTracking();
        }

        public IQueryable<TModel> GetAll()
        {
            return _applicationDataContext.Set<TModel>().Where(r => !r.IsDeleted).AsNoTracking();
        }

        public IQueryable<TModel> GetById(Guid id)
        {
            return _applicationDataContext.Set<TModel>().Where(r => r.Id == id).Where(r => !r.IsDeleted).AsNoTracking();
        }

        public async Task Update(TModel entity)
        {
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = Guid.Empty; // lay id nguoi update
            await _applicationDataContext.SaveChangesAsync();
        }

        public async Task UpdateMultiple(IList<TModel> entities)
        {
            foreach (var item in entities)
            {
                item.UpdatedOn = DateTime.Now;
                item.UpdatedBy = Guid.Empty; // lay id nguoi update
            }
            await _applicationDataContext.SaveChangesAsync();
        }
    }
}
