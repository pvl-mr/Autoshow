using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    public class PostLogic
    {
        private readonly IPostStorage PostStorage;

        public PostLogic(IPostStorage PostStorage)
        {
            this.PostStorage = PostStorage;
        }

        public List<PostViewModel> Read(PostBindingModel model)
        {
            if (model == null)
            {
                return PostStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PostViewModel> { PostStorage.GetElement(model) };
            }
            return PostStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PostBindingModel model)
        {
            var element = PostStorage.GetElement(new PostBindingModel { PostName = model.PostName });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть должность с таким названием");
            }
            if (model.Id.HasValue)
            {
                PostStorage.Update(model);
            }
            else
            {
                PostStorage.Insert(model);
            }
        }

        public void Delete(PostBindingModel model)
        {
            var element = PostStorage.GetElement(new PostBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            PostStorage.Delete(model);
        }
    }
}
