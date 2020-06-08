using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pactical.Interface;
using Practial.Domain;
using Practial.Domain.Models;
using Practial.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext context;
        public UnitOfWork(ApplicationContext _context)
        {
            context = _context;
        }
        
        public ResponseModel GetEmployee()
        {
            try
            {
                return new ResponseModel
                {
                    Data = context.Employee.ToList(),
                    Status = true
                };
            }
            catch (Exception e)
            {
                return new ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }
        }

        public ResponseModel AddEmployee(Employee model, IHubContext<Notification> notificationContext)
        {
            try
            {
                context.Employee.Add(model);
                context.SaveChanges();

                notificationContext.Clients.All.SendAsync("Message", "Employee added successfully" + Environment.NewLine + context.Employee.Count() + " number of employees are available.");

                return new ResponseModel()
                {
                    Message = "Employee added successfully",
                    Status = true
                };
            }
            catch (Exception e)
            {
                return new ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }            
        }

        public ResponseModel DeleteDepartment(string id)
        {
            try
            {
                if (id.Length > 1)
                {
                    return new ResponseModel
                    {
                        Message = "Department not exists",
                        Status = false
                    };                    
                }
                var department = context.Department.FirstOrDefault(x => x.DepartmentId == id[0]);
                if (department != null)
                {
                    context.Remove(department);
                    context.SaveChanges();

                    return new ResponseModel
                    {
                        Message = "Department deleted successfully",
                        Status = true
                    };
                }
                return new ResponseModel
                {
                    Message = "Department does not exists",
                    Status = true
                };
            }
            catch (Exception e)
            {
                return new ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }
        }

        public async Task<ResponseModel> GetAnnualBudgetAsync(int type)
        {
            try
            {
                var model = new List<AnnualBudgetModel>();
                switch (type)
                {
                    case 1:
                        var conn = context.Database.GetDbConnection();
                        await conn.OpenAsync();
                        var command = conn.CreateCommand();
                        const string query = "select Sum(d.\"AnnualBudget\")/Count(*) as AvarageAnuualBudget, d.\"DepartmentId\" from public.\"Employee\" as e inner join public.\"Department\" as d on d.\"DepartmentId\" = e.\"DepartmentId\" inner join public.\"Club\" as c on c.\"ClubId\" = e.\"ClubId\" where c.\"ClubId\" = 'A' group by d.\"DepartmentId\"";
                        command.CommandText = query;
                        var reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            model.Add(new AnnualBudgetModel
                            {
                                Club = "A",
                                Department = reader.GetString(1),
                                AnnualBudget = reader.GetDecimal(0).ToString()
                            });
                        }
                        break;
                    case 2:
                        model = context.Employee.Include(x => x.Department)
                            .Where(x => x.ClubId == 'A').ToList()
                            .GroupBy(x => x.DepartmentId)
                            .Select(x => new AnnualBudgetModel
                            {
                                Club = "A",
                                Department = x.Key.ToString(),
                                AnnualBudget = x.Average(y => y.Department.AnnualBudget).ToString()
                            }).ToList();
                        break;
                    case 3:
                        model = (from e in context.Employee
                                 join d in context.Department on e.DepartmentId equals d.DepartmentId
                                 where e.ClubId == 'A'
                                 group d by e.DepartmentId into g
                                 select new AnnualBudgetModel
                                 {
                                     Club = "A",
                                     Department = g.Key.ToString(),
                                     AnnualBudget = g.Average(x => x.AnnualBudget).ToString()
                                 }).ToList();
                        break;
                }
                return new ResponseModel()
                {
                    Data = model,
                    Status = true
                };
            }
            catch (Exception e)
            {
                return new ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }
        }
    }
}
