using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DataContext;
using API.Model;
using API.Repository.Interface;
using API.Services.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TService, TModel> : ControllerBase
        where TService : IBaseService<TModel>
        where TModel : BaseModel
    {
        protected readonly IBaseService<TModel> _service;

        public BaseController(IBaseService<TModel> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return ResponseResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);
            return ResponseResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TModel model)
        {
            var result = await _service.Update(id, model);
            return ResponseResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TModel model)
        {
            var result = await _service.Insert(model);
            return ResponseResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            return ResponseResult(result);
        }

        public IActionResult ResponseResult<T>(BaseResult<T> result)
        {
            return Ok(result);
        }
    }
}
