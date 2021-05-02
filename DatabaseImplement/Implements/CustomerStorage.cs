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
    public class CustomerStorage : ICustomerStorage
    {
        public List<CustomerViewModel> GetFullList()
        {
            using (var context = new AutoshowDbContext())
            {
                return context.Customers
                .Select(rec => new CustomerViewModel
                {
                    Id = rec.Id,
                    FirstName = rec.FirstName,
                    LastName = rec.LastName
                }).ToList();
            }
        }

        public List<CustomerViewModel> GetFilteredList(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                return context.Customers
                    .Where(rec => rec.FirstName.Contains(model.FirstName))
                    .Select(rec => new CustomerViewModel
                    {
                        Id = rec.Id,
                        FirstName = rec.FirstName,
                        LastName = rec.LastName
                    }).ToList();
            }
        }

        public CustomerViewModel GetElement(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                var Customer = context.Customers
                .FirstOrDefault(rec => rec.Id == model.Id);
                return Customer != null ?
                new CustomerViewModel
                {
                    Id = Customer.Id,
                    FirstName = Customer.FirstName,
                    LastName = Customer.LastName
                } : null;
            }
        }

        public void Insert(CustomerBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                context.Customers.Add(CreateModel(model, new Customer()));
                context.SaveChanges();
            }
        }

        public void Update(CustomerBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                var Customer = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);

                if (Customer == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, Customer);
                context.SaveChanges();
            }
        }

        public void Delete(CustomerBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                Customer Customer = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);

                if (Customer != null)
                {
                    context.Customers.Remove(Customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Сотрудник не найден");
                }
            }
        }

        private Customer CreateModel(CustomerBindingModel model, Customer Customer)
        {
            Customer.FirstName = model.FirstName;
            Customer.LastName = model.LastName;
            return Customer;
        }
    }
}
