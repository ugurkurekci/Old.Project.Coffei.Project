using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebMvc.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {

            var get = _companyService.getAll().Data;
            return View(get);
        }


        [HttpPost]
        public IActionResult Add(Company company)
        {


            if (ModelState.IsValid)
            {
                var result = _companyService.Add(company);

                if (result != null)
                {
                    if (result.Success)
                    {
                        return RedirectToAction("Index", "Company");
                    }
                    else
                    {
                        
                        return View("Add", "Company");
                    }

                }
            }

            return View(company);

        }

        [HttpPost]
        public IActionResult Updated(Company company, int id)
        {

            var update = _companyService.Update(company);
            var id2 = _companyService.getById(id).Data;
            if (update.Success)
            {

                id2.id = company.id;
                id2.companyName = company.companyName.Trim();
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Deleted(int id)
        {

            var id2 = _companyService.getById(id).Data;
            _companyService.Delete(id2);
            return RedirectToAction("Index");
        }





        public IActionResult Add()
        {
            return View();


        }

        public IActionResult Updated(int id)
        {
            return View();
        }

    }
}
