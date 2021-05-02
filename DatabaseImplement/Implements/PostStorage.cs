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
    public class PostStorage : IPostStorage
    {
        public List<PostViewModel> GetFullList()
        {
            using (var context = new AutoshowDbContext())
            {
                return context.Posts
                .Select(rec => new PostViewModel
                {
                    Id = rec.Id,
                    PostName = rec.PostName,
                    Salary = rec.Salary
                }).ToList();
            }
        }

        public List<PostViewModel> GetFilteredList(PostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                return context.Posts
                    .Where(rec => rec.PostName.Contains(model.PostName))
                    .Select(rec => new PostViewModel
                    {
                        Id = rec.Id,
                        PostName = rec.PostName,
                        Salary = rec.Salary
                    }).ToList();
            }
        }

        public PostViewModel GetElement(PostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AutoshowDbContext())
            {
                var Post = context.Posts
                .FirstOrDefault(rec => rec.Id == model.Id);
                return Post != null ?
                new PostViewModel
                {
                    Id = Post.Id,
                    PostName = Post.PostName,
                    Salary = Post.Salary
                } : null;
            }
        }

        public void Insert(PostBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                context.Posts.Add(CreateModel(model, new Post()));
                context.SaveChanges();
            }
        }

        public void Update(PostBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                var Post = context.Posts.FirstOrDefault(rec => rec.Id == model.Id);

                if (Post == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, Post);
                context.SaveChanges();
            }
        }

        public void Delete(PostBindingModel model)
        {
            using (var context = new AutoshowDbContext())
            {
                Post Post = context.Posts.FirstOrDefault(rec => rec.Id == model.Id);

                if (Post != null)
                {
                    context.Posts.Remove(Post);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Сотрудник не найден");
                }
            }
        }

        private Post CreateModel(PostBindingModel model, Post Post)
        {
            Post.PostName = model.PostName;
            Post.Salary = model.Salary;
            return Post;
        }
    }
}
