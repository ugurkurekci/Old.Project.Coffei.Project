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
        ICompanyService _companyService;

        public AdminController(ICategoryService categoryService,ICompanyService companyService)
        {
            _categoryService = categoryService;
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var categoryresult = _categoryService.GetAll().Data.Count();
            var companyresult = _companyService.GetAll().Data.Count(); 
            ViewBag.r1 = categoryresult;
            ViewBag.r2 = companyresult;
            return View();

        }
    }
}
