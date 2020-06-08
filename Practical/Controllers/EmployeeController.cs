using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Pactical.Interface;
using Practial.Domain;
using Practial.Domain.Models;
using Practial.Domain.Notification;

namespace Practical.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IHubContext<Notification> notificationContext;

        public EmployeeController(IUnitOfWork _uow, IHubContext<Notification> _notificationContext)
        {
            uow = _uow;
            notificationContext = _notificationContext;
        }

        [HttpGet]
        public ResponseModel Get()
        {
            return uow.GetEmployee();
        }

        [HttpPost]
        public ResponseModel Post(Employee model)
        {
            return uow.AddEmployee(model, notificationContext);
        }

        [HttpGet]
        [Route("GetAnnualBudget")]
        public async Task<ResponseModel> GetAnnualBudgetAsync(int type)
        {
            return await uow.GetAnnualBudgetAsync(type);
        }
    }
}
