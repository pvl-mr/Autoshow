using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    public class BranchLogic
    {
        private readonly IBranchStorage BranchStorage;

        public BranchLogic(IBranchStorage BranchStorage)
        {
            this.BranchStorage = BranchStorage;
        }

        public List<BranchViewModel> Read(BranchBindingModel model)
        {
            if (model == null)
            {
                return BranchStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<BranchViewModel> { BranchStorage.GetElement(model) };
            }
            return BranchStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(BranchBindingModel model)
        {
            var element = BranchStorage.GetElement(new BranchBindingModel { BranchName = model.BranchName });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть филиал с таким названием");
            }
            if (model.Id.HasValue)
            {
                BranchStorage.Update(model);
            }
            else
            {
                BranchStorage.Insert(model);
            }
        }

        public void Delete(BranchBindingModel model)
        {
            var element = BranchStorage.GetElement(new BranchBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            BranchStorage.Delete(model);
        }
    }
}
