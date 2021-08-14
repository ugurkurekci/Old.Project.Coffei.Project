using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace NetCoreWebMvc.Controllers
{
    public class AdminController : Controller
    {
        ICategoryService _categoryService;
        ICompanyService _companyService;
        IContactService _contactService;
        IOrder_PortionService _order_PortionService;
        IOrder_TypeService _order_TypeService;

        public AdminController(ICategoryService categoryService,ICompanyService companyService,IContactService contactService,IOrder_TypeService order_TypeService,IOrder_PortionService order_PortionService)
        {
            _categoryService = categoryService;
            _companyService = companyService;
            _contactService = contactService;
            _order_PortionService = order_PortionService;
            _order_TypeService = order_TypeService;
        }

        public IActionResult Index()
        {
            var categoryresult = _categoryService.GetAll().Data.Count();
            var companyresult = _companyService.GetAll().Data.Count();
            var ordertyperesult = _order_TypeService.GetAll().Data.Count();
            var orderportionresult = _order_PortionService.GetAll().Data.Count();
            ViewBag.r1 = categoryresult;
            ViewBag.r2 = companyresult;
            ViewBag.r3 = ordertyperesult;
            ViewBag.r4 = orderportionresult;
            return View();

        }
    }
}
