using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DataContext;
using API.Model;
using API.Repository;
using API.Repository.Interface;

namespace API.Controllers
{
    public class ContractController : BaseController<IContractRepository, Contract>
    {
        public ContractController(IContractRepository repository) : base(repository)
        {
        }
    }
}
