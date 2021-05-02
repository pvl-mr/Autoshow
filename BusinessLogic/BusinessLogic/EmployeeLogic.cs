using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    public class EmployeeLogic
    {
        private readonly IEmployeeStorage EmployeeStorage;

        public EmployeeLogic(IEmployeeStorage EmployeeStorage)
        {
            this.EmployeeStorage = EmployeeStorage;
        }

        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return EmployeeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { EmployeeStorage.GetElement(model) };
            }
            return EmployeeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            var element = EmployeeStorage.GetElement(new EmployeeBindingModel { FirstName = model.FirstName });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть работник с таким именем");
            }
            if (model.Id.HasValue)
            {
                EmployeeStorage.Update(model);
            }
            else
            {
                EmployeeStorage.Insert(model);
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            var element = EmployeeStorage.GetElement(new EmployeeBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            EmployeeStorage.Delete(model);
        }
    }
}
