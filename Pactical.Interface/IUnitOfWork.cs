using Microsoft.AspNetCore.SignalR;
using Practial.Domain;
using Practial.Domain.Models;
using Practial.Domain.Notification;
using System;
using System.Threading.Tasks;

namespace Pactical.Interface
{
    public interface IUnitOfWork
    {
        ResponseModel GetEmployee();
        ResponseModel AddEmployee(Employee model, IHubContext<Notification> notificationContext);
        ResponseModel DeleteDepartment(string id);
        Task<ResponseModel> GetAnnualBudgetAsync(int type);
    }
}
