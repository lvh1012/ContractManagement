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
    public class ProductController : BaseController<IProductService, Product>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
