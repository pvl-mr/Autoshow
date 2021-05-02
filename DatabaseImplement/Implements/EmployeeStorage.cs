using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public List<EmployeeViewModel> GetFullList()
        {
            using (var context = new AutoshowDbContext())
            {
                return context.Employees
                .Select(rec => new EmployeeViewModel
                {
                    Id = rec.Id,
                    FirstName = rec.FirstName,
                    LastName  = rec.LastName,
                    BranchId = rec.BranchId,
                    PostId = rec.PostId
                }).ToList();
            }
        }

        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                return context.Employees
                    .Where(rec => rec.FirstName.Contains(model.FirstName))
                    .Select(rec => new EmployeeViewModel
                    {
                        Id = rec.Id,
                        FirstName = rec.FirstName,
                        LastName = rec.LastName,
                        BranchId = rec.BranchId,
                        PostId = rec.PostId
                    }).ToList();
            }
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                var employee = context.Employees
                .FirstOrDefault(rec => rec.Id == model.Id);
                return employee != null ?
                new EmployeeViewModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    BranchId = employee.BranchId,
                    PostId = employee.PostId
                } : null;
            }
        }

        public void Insert(EmployeeBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                context.Employees.Add(CreateModel(model, new Employee()));
                context.SaveChanges();
            }
        }

        public void Update(EmployeeBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                var employee = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);

                if (employee == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, employee);
                context.SaveChanges();
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                Employee employee = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);

                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Сотрудник не найден");
                }
            }
        }

        private Employee CreateModel(EmployeeBindingModel model, Employee employee)
        {
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.PostId = model.PostId;
            employee.BranchId = model.BranchId;
            return employee;
        }
    }
}
