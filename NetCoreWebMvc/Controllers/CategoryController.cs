using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebMvc.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public IActionResult Index()
        {
            var result = _categoryService.GetAll().Data;
            return View(result);
        }

        public IActionResult AddCategory()
        {
            return View();
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


    }
}
