using API.Model;
using API.Repository.Interface;
using API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Z.Expressions;

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

        public async Task<BaseResult<List<TModel>>> GetData(Page page)
        {
            var filter = new Filter("price", Operator.Equal, 99);
            var ex = CreatePredicateForFilter(filter);
            var query = _repository.GetAll().Where(ex).OrderByDescending(CreateSelector("price"));
            var data = await GetPage(query, page);
            return BaseResult<List<TModel>>.ReturnWithData(data.Data, page);
        }

        public async Task<BaseResult<List<TModel>>> GetPage(IQueryable<TModel> query, Page page)
        {
            var totalRow = await query.CountAsync();
            var totalPage = (int)Math.Ceiling(totalRow / (double)page.PageSize);
            if (page.PageNumber > totalPage)
            {
                page.PageNumber = totalPage;
            }

            page.TotalRow = totalRow;
            page.TotalPage = totalPage;

            var data = await query.Skip((page.PageNumber - 1) * page.PageSize).Take(page.PageSize).ToListAsync();
            return BaseResult<List<TModel>>.ReturnWithData(data);
        }

        public async Task<BaseResult<List<object>>> GetDataDynamic(Page page)
        {
            var data = await _repository.GetAll().SelectManyDynamic(r => "r.Code").Skip((page.PageNumber - 1) * page.PageSize).Take(page.PageSize).ToListAsync();
            return BaseResult<List<object>>.ReturnWithData(data);
        }

        public static Expression<Func<TModel, object>> CreateSelector(string field)
        {
            var xType = typeof(TModel);
            var x = Expression.Parameter(xType, "x");
            var column = xType.GetProperties().FirstOrDefault(p => string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));
            Expression conversion = Expression.Convert(Expression.PropertyOrField(x, column.Name), typeof(object));   //important to use the Expression.Convert
            return Expression.Lambda<Func<TModel, object>>(conversion, x);
        }

        public static Expression<Func<TModel, bool>> CreatePredicateForFilter(Filter filter)
        {
            var field = filter.Field;
            var value = filter.Value;
            var op = filter.Operator;

            var xType = typeof(TModel);
            var x = Expression.Parameter(xType, "x");
            var column = xType.GetProperties().FirstOrDefault(p => string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));

            Expression body = (Expression)Expression.Constant(true);
            if (column != null)
            {
                var me = Expression.PropertyOrField(x, column.Name);
                var constant = Expression.Constant(value);

                if (op.Equals(Operator.Less))
                {
                    body = Expression.LessThan(me, constant);
                }
                else if (op.Equals(Operator.LessOrEqual))
                {
                    body = Expression.LessThanOrEqual(me, constant);
                }
                else if (op.Equals(Operator.Greater))
                {
                    body = Expression.GreaterThan(me, constant);
                }
                else if (op.Equals(Operator.GreaterOrEqual))
                {
                    body = Expression.GreaterThanOrEqual(me, constant);
                }
                else if (op.Equals(Operator.Equal))
                {
                    body = Expression.Equal(me, constant);
                }
                else if (op.Equals(Operator.NotEqual))
                {
                    body = Expression.NotEqual(me, constant);
                }
                else if (op.Equals(Operator.Contain))
                {
                    body = Expression.Call(me, typeof(string).GetMethod("Contains", new[] { typeof(string) }), constant);
                }
                else
                {
                    body = (Expression)Expression.Constant(true);
                }
            }

            return Expression.Lambda<Func<TModel, bool>>(body, x);
        }

        public static Expression<Func<TModel, bool>> CreatePredicateForFilter(List<Filter> filters)
        {
            var xType = typeof(TModel);
            var x = Expression.Parameter(xType, "x");

            Expression body = (Expression)Expression.Constant(true);
            foreach (var filter in filters)
            {
                body = Expression.AndAlso(body, CreatePredicateForFilter(filter).Body);
            }

            return Expression.Lambda<Func<TModel, bool>>(body, x);
        }
    }
}
