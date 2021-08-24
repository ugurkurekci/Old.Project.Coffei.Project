using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace NetCoreWebMvc.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {


            _categoryService = categoryService;

        }

        public ActionResult Index()
        {

            var get = _categoryService.getAll().Data;
            return View(get);

        }



        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(category);
            if (result.IsValid)
            {

                var dataa = new Category
                {
                    categoryName = category.categoryName,
                    isActive = category.isActive


                };
                var categoryresult = _categoryService.Add(dataa);
                if (categoryresult.Success)
                {

                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    return RedirectToAction("Add", "Category");
                }


            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Updated(Category category, int id)
        {

            var update = _categoryService.Update(category);
            var id2 = _categoryService.getById(id).Data;
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

            var id2 = _categoryService.getById(id).Data;
            _categoryService.Delete(id2);
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










