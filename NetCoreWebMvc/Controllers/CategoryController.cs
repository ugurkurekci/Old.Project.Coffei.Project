using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        public ActionResult Index(string searching, int page = 1)
        {
            if (!string.IsNullOrEmpty(searching))
            {
                var searchget = _categoryService.GetByCategoryName(searching).Data.ToPagedList(page, 10);
                ViewBag.searchmessage = "Aranan Kelime Listelendi";

                return View(searchget);
            }
            else
            {
                ViewBag.notsearchmessage = "Aranan Kelime Bulunamadı";

            }

            var get = _categoryService.GetAll().Data.ToPagedList(page, 10);
            ViewBag.message = "Success, listelendi";


            return View(get);

        }



        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(category);
            if (result.IsValid)
            {
                var added = _categoryService.Add(category);
                if (added.Success)
                {
                    ViewBag.addedsucces = "Kategori Eklendi";
                    return RedirectToAction("Index");
                }
               
            }
           
            return View();
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
            return View();

        }

        public IActionResult Deleted(int id)
        {

            var id2 = _categoryService.GetByid(id).Data;
            _categoryService.Delete(id2);
            return RedirectToAction("Index");
        }



        public PartialViewResult Notification(bool operation)
        {

            return PartialView(_categoryService.GetByIsActive(operation).Data);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();


        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }








    }
}
