using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IBranchStorage
    {
        List<BranchViewModel> GetFullList();
        List<BranchViewModel> GetFilteredList(BranchBindingModel model);
        BranchViewModel GetElement(BranchBindingModel model);
        void Insert(BranchBindingModel model);
        void Update(BranchBindingModel model);
        void Delete(BranchBindingModel model);
    }
}
