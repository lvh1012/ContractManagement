using API.DataContext;
using API.Model;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<TModel> Insert(TModel entity)
        {
            entity.Id = Guid.NewGuid();
            var now = DateTime.Now;
            entity.CreatedOn = now;
            entity.CreatedBy = Guid.Empty;
            entity.UpdatedOn = now;
            entity.UpdatedBy = Guid.Empty;
            await _applicationDataContext.AddAsync(entity);
            await _applicationDataContext.SaveChangesAsync();
            return entity;
        }

        public async Task InsertMultiple(IList<TModel> entities)
        {
            var now = DateTime.Now;
            foreach (var item in entities)
            {
                item.Id = Guid.NewGuid();
                item.CreatedOn = now;
                item.CreatedBy = Guid.Empty;
                item.UpdatedOn = now;
                item.UpdatedBy = Guid.Empty;
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

        public IQueryable<TModel> GetByCondition(Expression<Func<TModel, bool>> expression)
        {
            return _applicationDataContext.Set<TModel>().Where(expression).Where(r => !r.IsDeleted).AsNoTracking();
        }

        public IQueryable<TModel> GetAll()
        {
            return _applicationDataContext.Set<TModel>().Where(r => !r.IsDeleted).AsNoTracking();
        }

        public async Task<TModel> GetById(Guid id)
        {
            return await _applicationDataContext.Set<TModel>().Where(r => r.Id == id).Where(r => !r.IsDeleted).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TModel> Update(TModel entity)
        {
            _applicationDataContext.Set<TModel>().Attach(entity);
            _applicationDataContext.Entry(entity).State = EntityState.Modified;

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = Guid.Empty; // lay id nguoi update

            await _applicationDataContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateMultiple(IList<TModel> entities)
        {
            _applicationDataContext.Set<TModel>().AttachRange(entities);
            _applicationDataContext.Entry(entities).State = EntityState.Modified;

            var now = DateTime.Now;
            foreach (var item in entities)
            {
                item.UpdatedOn = now;
                item.UpdatedBy = Guid.Empty; // lay id nguoi update
            }
            await _applicationDataContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                await Delete(entity);
            }
        }

        public async Task<bool> CheckExist(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                return true;
            }
            return false;
        }
    }
}
