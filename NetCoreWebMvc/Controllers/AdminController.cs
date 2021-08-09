using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebMvc.Controllers
{
    public class AdminController : Controller
    {
        ICategoryService _categoryService;

        public AdminController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var result = _categoryService.GetAll().Data.Count();
            ViewBag.r1 = result;
            return View();

        }
    }
}
