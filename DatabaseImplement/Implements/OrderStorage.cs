using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new AutoshowDbContext())
            {
                return context.Orders
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.Customer)
                    .Include(rec => rec.Car)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        Date = rec.Date,
                        CarId = rec.CarId,
                        EmployeeId = rec.EmployeeId,
                        CustomerId = rec.CustomerId,
                        CarName = rec.Car.Model,
                        EmployeeName = rec.EmployeeId.HasValue ? rec.Employee.FirstName : string.Empty,
                        CustomerName = rec.Customer.FirstName
                    }).ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                return context.Orders
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.Customer)
                    .Include(rec => rec.Car)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        Date = rec.Date,
                        CarId = rec.CarId,
                        EmployeeId = rec.EmployeeId,
                        CustomerId = rec.CustomerId,
                        CarName = rec.Car.Model,
                        EmployeeName = rec.EmployeeId.HasValue ? rec.Employee.FirstName : string.Empty,
                        CustomerName = rec.Customer.FirstName
                    }).ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                var order = context.Orders
                   .Include(rec => rec.Employee)
                    .Include(rec => rec.Customer)
                    .Include(rec => rec.Car)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    Date = order.Date,
                    CarId = order.CarId,
                    EmployeeId = order.EmployeeId,
                    CustomerId = order.CustomerId,
                    CarName = order.Car.Model,
                    EmployeeName = order.EmployeeId.HasValue ? order.Employee.FirstName : string.Empty,
                    CustomerName = order.Customer.FirstName
                } : null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                var Order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (Order == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, Order);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                Order Order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (Order != null)
                {
                    context.Orders.Remove(Order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Сотрудник не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order Order)
        {
            Order.Date = model.Date;
            Order.CarId = model.CarId;
            Order.CustomerId = model.CustomerId;
            Order.EmployeeId = model.EmployeeId;
            return Order;
        }
    }
}
