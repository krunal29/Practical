using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pactical.Interface;
using Practial.Domain;
using Practial.Domain.Models;

namespace Practical.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public DepartmentController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpDelete]
        public ResponseModel Delete(string id)
        {
            return uow.DeleteDepartment(id);
        }
    }
}
