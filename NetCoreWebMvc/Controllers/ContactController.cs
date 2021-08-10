using Business.Abstract;
using Core.Utilities.Results;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using X.PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebMvc.Controllers
{
    public class ContactController : Controller
    {
        IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index(string searching, int page = 1)
        {
            if (!string.IsNullOrEmpty(searching))
            {
                var get = _contactService.GetByEmail(searching).Data.ToPagedList(page, 10);
                ViewBag.searchmessage = "Aranan Kelime Listelendi";
                return View(get);
            }
            else
            {
                ViewBag.notsearchmessage = "Aranan Kelime Bulunamadı";

            }

            var result = _contactService.GetAll().Data.ToPagedList(page, 10);
            ViewBag.message = "Success, listelendi";


            return View(result);

        }



        [HttpPost]
        public IActionResult Added(Contact contact)
        {



            if (ModelState.IsValid)
            {
                var result = _contactService.Add(contact);

                if (result != null)
                {
                    if (result.Success)
                    {
                        ViewBag.addedsucces = "İletişim Eklendi.";
                        return View("Add");
                    }
                    else
                    {
                        ViewBag.notsuccess = "İletişim Eklenemedi.";
                        return View("Add");
                    }

                }
            }

            return RedirectToAction("Add");



        }

        [HttpPost]
        public IActionResult Updated(Contact contact, int id)
        {

            var update = _contactService.Update(contact);
            var id2 = _contactService.GetByid(id).Data;
            if (update.Success)
            {

                id2.id = contact.id;
                id2.email = contact.email.Trim();
                id2.message = contact.message.Trim();
                id2.name = contact.name.Trim();
                id2.subject = contact.subject.Trim();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public IActionResult Deleted(int id)
        {

            var id2 = _contactService.GetByid(id).Data;
            _contactService.Delete(id2);
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
