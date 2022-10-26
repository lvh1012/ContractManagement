using API.Model;
using API.Repository.Interface;
using API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BaseService<TRepository, TModel> : IBaseService<TModel>
        where TRepository : IBaseRepository<TModel>
        where TModel : BaseModel
    {
        protected readonly IBaseRepository<TModel> _repository;

        public BaseService(IBaseRepository<TModel> repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<TModel>> Insert(TModel model)
        {
            var data = await _repository.Insert(model);
            return BaseResult<TModel>.ReturnWithData(data);
        }

        public async Task<BaseResult<bool>> Delete(Guid id)
        {
            await _repository.Delete(id);
            return BaseResult<bool>.ReturnWithData(true);
        }

        public async Task<BaseResult<List<TModel>>> GetAll()
        {
            var data = await _repository.GetAll().ToListAsync();
            return BaseResult<List<TModel>>.ReturnWithData(data);
        }

        public async Task<BaseResult<TModel>> GetById(Guid id)
        {
            var data = await _repository.GetById(id);
            return BaseResult<TModel>.ReturnWithData(data);
        }

        public async Task<BaseResult<TModel>> Update(Guid id, TModel model)
        {
            var modelExist = await _repository.CheckExist(id);
            if (modelExist)
            {
                var data = await _repository.Update(model);
                return BaseResult<TModel>.ReturnWithData(data);
            }
            return BaseResult<TModel>.ReturnWithData(model);

        }
    }
}
