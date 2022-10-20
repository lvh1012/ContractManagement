using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interface
{
    public interface IBaseService<TModel>
    {
        Task<BaseResult<List<TModel>>> GetAll();
        Task<BaseResult<TModel>> GetById(Guid id);
        Task<BaseResult<TModel>> Insert(TModel model);
        Task<BaseResult<TModel>> Update(Guid id, TModel model);
        Task<BaseResult<bool>> Delete(Guid id);
    }
}
