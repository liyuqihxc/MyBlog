using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.App;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    class CategoriesController : Controller
    {
        CategoriesApp _CategoryApp { get; }

        public CategoriesController(CategoriesApp cateApp)
        {
            _CategoryApp = cateApp;
        }

        public KeyLabelModel<int>[] Get()
        {
            return _CategoryApp.GetAllCategories().ToArray();
        }
    }
}
