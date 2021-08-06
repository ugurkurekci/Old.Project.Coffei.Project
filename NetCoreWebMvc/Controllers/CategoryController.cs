using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NetCoreWebMvc.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        CategoryManager manager = new CategoryManager(new EfCategoryDal());


        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var result = _categoryService.GetAll().Data.ToPagedList(page, 5);
            return View(result);
        }


        [HttpPost]
        public IActionResult Added(Category category)
        {
            var result = _categoryService.Add(category);

            if (result != null)
            {
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("AddCategory");



        }

        [HttpPost]
        public IActionResult Updated(Category category, int id)
        {
            var id2 = _categoryService.GetByid(id);
            id2.Data.id = category.id;
            id2.Data.categoryName = category.categoryName;
            id2.Data.isActive = category.isActive;


            var update = _categoryService.Update(category);
            if (update.Success)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("UpdateCategory");


        }
        public IActionResult AddCategory()
        {

            return View();

        }

        public IActionResult UpdateCategory()
        {
            return View();
        }










    }
}
