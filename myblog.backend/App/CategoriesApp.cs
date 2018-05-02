using System;
using System.Collections.Generic;
using MyBlog.Domain.IRepository;
using MyBlog.Models;

namespace MyBlog.App
{
    public class CategoriesApp
    {
        ICategoriesRepository _CategoriesRepository { get; }

        IArticlesRepository _ArticlesRepository { get; }

        public CategoriesApp(ICategoriesRepository cateRepo, IArticlesRepository articleRepo)
        {
            _CategoriesRepository = cateRepo;
            _ArticlesRepository = articleRepo;
        }

        public IEnumerable<KeyLabelModel<int>> GetAllCategories()
        {
            var cats = _CategoriesRepository.All();
            List<KeyLabelModel<int>> list = new List<KeyLabelModel<int>>();
            foreach(var cat in cats)
            {
                list.Add(new KeyLabelModel<int>
                {
                    Key = cat.ID,
                    Label = cat.Name
                });
            }
            return list;
        }
    }
}
