using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.Interfaces
{
    public interface ICarStorage
    {
        List<CarViewModel> GetFullList();
        List<CarViewModel> GetFilteredList(CarBindingModel model);
        CarViewModel GetElement(CarBindingModel model);
        void Insert (CarBindingModel model);
        void Update(CarBindingModel model);
        void Delete(CarBindingModel model);
    }
}
