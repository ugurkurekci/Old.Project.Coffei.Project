using Business.Abstract;
using Business.Concrete;
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
        public IActionResult Index(int page=1)
        {
            var result = _categoryService.GetAll().Data.ToPagedList(page,5);
            return View(result);
        }


        [HttpPost]
        public IActionResult Added(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpPut]
        public IActionResult Updated(Category category)
        {
            var update = _categoryService.Update(category);
            if (update.Success)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");


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
