﻿using Business.Abstract;
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

            var update = _categoryService.Update(category);
            var id2 = _categoryService.GetByid(id).Data;
            if (update.Success)
            {

                id2.id = category.id;
                id2.categoryName = category.categoryName.Trim();
                id2.isActive = category.isActive;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        
        public IActionResult Deleted(int id)
        {

            var id2 = _categoryService.GetByid(id).Data;
            _categoryService.Delete(id2);
            return RedirectToAction("Index");


        }


        public IActionResult AddCategory()
        {
            return View();
           

        }

        public IActionResult UpdateCategory(int id)
        {
            return View();
        }










    }
}
