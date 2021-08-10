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
        IContactService _contactService;

        public AdminController(ICategoryService categoryService,ICompanyService companyService,IContactService contactService)
        {
            _categoryService = categoryService;
            _companyService = companyService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var categoryresult = _categoryService.GetAll().Data.Count();
            var companyresult = _companyService.GetAll().Data.Count();
            var contactresult = _contactService.GetAll().Data.Count();
            ViewBag.r1 = categoryresult;
            ViewBag.r2 = companyresult;
            ViewBag.r3 = contactresult;
            return View();

        }
    }
}
