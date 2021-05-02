using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    public class CarLogic
    {
        private readonly ICarStorage CarStorage;

        public CarLogic(ICarStorage CarStorage)
        {
            this.CarStorage = CarStorage;
        }

        public List<CarViewModel> Read(CarBindingModel model)
        {
            if (model == null)
            {
                return CarStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CarViewModel> { CarStorage.GetElement(model) };
            }
            return CarStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CarBindingModel model)
        {
            var element = CarStorage.GetElement(new CarBindingModel { Model = model.Model });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть автомобиль такой модели");
            }
            if (model.Id.HasValue)
            {
                CarStorage.Update(model);
            }
            else
            {
                CarStorage.Insert(model);
            }
        }

        public void Delete(CarBindingModel model)
        {
            var element = CarStorage.GetElement(new CarBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CarStorage.Delete(model);
        }
    }
}
