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
    public class BranchStorage : IBranchStorage
    {
        public List<BranchViewModel> GetFullList()
        {
            using (var context = new AutoshowDbContext())
            {
                return context.Branches
                .Select(rec => new BranchViewModel
                {
                    Id = rec.Id,
                    Address = rec.Address,
                    BranchName = rec.BranchName
                }).ToList();
            }
        }

        public List<BranchViewModel> GetFilteredList(BranchBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                return context.Branches
                    .Where(rec => rec.BranchName.Contains(model.BranchName))
                    .Select(rec => new BranchViewModel
                    {
                        Id = rec.Id,
                        Address = rec.Address,
                        BranchName = rec.BranchName
                    }).ToList();
            }
        }

        public BranchViewModel GetElement(BranchBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                var Branch = context.Branches
                .FirstOrDefault(rec => rec.Id == model.Id);
                return Branch != null ?
                new BranchViewModel
                {
                    Id = Branch.Id,
                    Address = Branch.Address,
                    BranchName = Branch.BranchName
                } : null;
            }
        }

        public void Insert(BranchBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                context.Branches.Add(CreateModel(model, new Branch()));
                context.SaveChanges();
            }
        }

        public void Update(BranchBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                var Branch = context.Branches.FirstOrDefault(rec => rec.Id == model.Id);

                if (Branch == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, Branch);
                context.SaveChanges();
            }
        }

        public void Delete(BranchBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                Branch Branch = context.Branches.FirstOrDefault(rec => rec.Id == model.Id);

                if (Branch != null)
                {
                    context.Branches.Remove(Branch);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Сотрудник не найден");
                }
            }
        }

        private Branch CreateModel(BranchBindingModel model, Branch Branch)
        {
            Branch.Address = model.Address;
            Branch.BranchName = model.BranchName;
            return Branch;
        }
    }
}
