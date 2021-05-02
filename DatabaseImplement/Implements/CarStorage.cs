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
    public class CarStorage : ICarStorage
    {
        public List<CarViewModel> GetFullList()
        {
            using (var context = new AutoshowDbContext())
            {
                return context.Cars
                .Select(rec => new CarViewModel
                {
                    Id = rec.Id,
                    Model = rec.Model,
                    Color = rec.Color,
                    Price = rec.Price
                }).ToList();
            }
        }

        public List<CarViewModel> GetFilteredList(CarBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                return context.Cars
                    .Where(rec => rec.Model.Contains(model.Model))
                    .Select(rec => new CarViewModel
                    {
                        Id = rec.Id,
                        Model = rec.Model,
                        Color = rec.Color,
                        Price = rec.Price
                    }).ToList();
            }
        }

        public CarViewModel GetElement(CarBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                var Car = context.Cars
                .FirstOrDefault(rec => rec.Id == model.Id);
                return Car != null ?
                new CarViewModel
                {
                    Id = Car.Id,
                    Model = Car.Model,
                    Color = Car.Color,
                    Price = Car.Price
                } : null;
            }
        }

        public void Insert(CarBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                context.Cars.Add(CreateModel(model, new Car()));
                context.SaveChanges();
            }
        }

        public void Update(CarBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                var Car = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);

                if (Car == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, Car);
                context.SaveChanges();
            }
        }

        public void Delete(CarBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                Car Car = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);

                if (Car != null)
                {
                    context.Cars.Remove(Car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Сотрудник не найден");
                }
            }
        }

        private Car CreateModel(CarBindingModel model, Car Car)
        {
            Car.Model = model.Model;
            Car.Color = model.Color;
            Car.Price = model.Price;
            Car.BranchId = model.BranchId;
            return Car;
        }
    }
}
