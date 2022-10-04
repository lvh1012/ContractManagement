using API.DataContext;
using API.Model;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly ApplicationDataContext _applicationDataContext;

        protected BaseRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }

        public async Task Insert(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = Guid.Empty;
            await _applicationDataContext.AddAsync(entity);
            await _applicationDataContext.SaveChangesAsync();
        }

        public async Task InsertMultiple(IList<T> entities)
        {
            foreach (var item in entities)
            {
                item.CreatedOn = DateTime.Now;
                item.CreatedBy = Guid.Empty;
            }
            await _applicationDataContext.AddRangeAsync(entities);
            await _applicationDataContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            entity.IsDeleted = true;
            await Update(entity);
        }

        public async Task DeleteMultiple(IList<T> entities)
        {
            foreach (var item in entities)
            {
                item.IsDeleted = true;
            }
            await UpdateMultiple(entities);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _applicationDataContext.Set<T>().Where(expression).Where(r => !r.IsDeleted).AsNoTracking();
        }

        public IQueryable<T> GetAll()
        {
            return _applicationDataContext.Set<T>().Where(r => !r.IsDeleted).AsNoTracking();
        }

        public IQueryable<T> GetById(Guid id)
        {
            return _applicationDataContext.Set<T>().Where(r => r.Id == id).Where(r => !r.IsDeleted).AsNoTracking();
        }

        public async Task Update(T entity)
        {
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = Guid.Empty; // lay id nguoi update
            await _applicationDataContext.SaveChangesAsync();
        }

        public async Task UpdateMultiple(IList<T> entities)
        {
            foreach (T item in entities)
            {
                item.UpdatedOn = DateTime.Now;
                item.UpdatedBy = Guid.Empty; // lay id nguoi update
            }
            await _applicationDataContext.SaveChangesAsync();
        }
    }
}
