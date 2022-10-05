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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TRepository, TModel> : ControllerBase
        where TRepository : IBaseRepository<TModel>
        where TModel : BaseModel
    {
        protected readonly IBaseRepository<TModel> _repository;

        public BaseController(IBaseRepository<TModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TModel>>> GetAll()
        {
            var query = _repository.GetAll();
            return await _repository.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TModel>> GetById(Guid id)
        {
            return await _repository.GetById(id).FirstOrDefaultAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _repository.Update(model);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<TModel>> Create(TModel model)
        {
            await _repository.Insert(model);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _repository.GetById(id).FirstOrDefaultAsync();
            if (model == null)
            {
                return NotFound();
            }

            await _repository.Delete(model);
            return Ok();
        }
    }
}
