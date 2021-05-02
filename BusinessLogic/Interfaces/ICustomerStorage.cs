using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;

namespace BusinessLogic.Interfaces
{
    public interface ICustomerStorage
    {
        List<CustomerViewModel> GetFullList();
        List<CustomerViewModel> GetFilteredList(CustomerBindingModel model);
        CustomerViewModel GetElement(CustomerBindingModel model);
        void Insert(CustomerBindingModel model);
        void Update(CustomerBindingModel model);
        void Delete(CustomerBindingModel model);
    }
}
