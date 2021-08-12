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

                var dataa = new Category
                {
                    categoryName = category.categoryName,
                    isActive=category.isActive
                    

                };
                var categoryresult =_categoryService.Add(dataa);
                if (categoryresult.Success)
                {
                    
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    return RedirectToAction("Add", "Category");
                }
               

            }
            return View(result);
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



           
        public IActionResult Add()
        {
            return View();


        }
       
        public IActionResult Updated(int id)
        {
            return View();
        }

        public ActionResult getSum(string number1, string number2)
        {
            int number_1 = int.TryParse(number1, out int defaultValue1) ? defaultValue1 : 0;
            int number_2 = int.TryParse(number2, out int defaultValue2) ? defaultValue2 : 0;

            int result = number_1 + number_2;
            return Json(result);
        }



    }
}
