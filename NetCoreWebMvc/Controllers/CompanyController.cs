using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NetCoreWebMvc.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index(string searching, int page = 1)
        {
            if (!string.IsNullOrEmpty(searching))
            {
                var get = _companyService.GetByCompanyName(searching).Data.ToPagedList(page, 10);
                ViewBag.searchmessage = "Aranan Kelime Listelendi";
                return View(get);
            }
            else
            {
                ViewBag.notsearchmessage = "Aranan Kelime Bulunamadı";

            }

            var result = _companyService.GetAll().Data.ToPagedList(page, 10);
            ViewBag.message = "Success, listelendi";


            return View(result);
        }


        [HttpPost]
        public IActionResult Added(Company company)
        {



            if (ModelState.IsValid)
            {
                var result = _companyService.Add(company);

                if (result != null)
                {
                    if (result.Success)
                    {
                        ViewBag.addedsucces = "Firma Eklendi.";
                        return View("Add");
                    }
                    else
                    {
                        ViewBag.notsuccess = "Firma Eklenemedi.";
                        return View("Add");
                    }

                }
            }

            return RedirectToAction("Add");



        }

        [HttpPost]
        public IActionResult Updated(Company company, int id)
        {

            var update = _companyService.Update(company);
            var id2 = _companyService.GetById(id).Data;
            if (update.Success)
            {

                id2.id = company.id;
                id2.companyName = company.companyName.Trim();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public IActionResult Deleted(int id)
        {

            var id2 = _companyService.GetById(id).Data;
            _companyService.Delete(id2);
            return RedirectToAction("Index");
        }





        public IActionResult Add()
        {
            return View();


        }

        public IActionResult Update(int id)
        {
            return View();
        }

    }
}
