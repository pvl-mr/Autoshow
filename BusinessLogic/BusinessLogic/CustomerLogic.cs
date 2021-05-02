using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    public class CustomerLogic
    {
        private readonly ICustomerStorage CustomerStorage;

        public CustomerLogic(ICustomerStorage CustomerStorage)
        {
            this.CustomerStorage = CustomerStorage;
        }

        public List<CustomerViewModel> Read(CustomerBindingModel model)
        {
            if (model == null)
            {
                return CustomerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CustomerViewModel> { CustomerStorage.GetElement(model) };
            }
            return CustomerStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CustomerBindingModel model)
        {
            var element = CustomerStorage.GetElement(new CustomerBindingModel { FirstName = model.FirstName });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть покупатель с таким именем");
            }
            if (model.Id.HasValue)
            {
                CustomerStorage.Update(model);
            }
            else
            {
                CustomerStorage.Insert(model);
            }
        }

        public void Delete(CustomerBindingModel model)
        {
            var element = CustomerStorage.GetElement(new CustomerBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CustomerStorage.Delete(model);
        }
    }
}
