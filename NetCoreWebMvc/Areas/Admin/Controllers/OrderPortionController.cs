using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebMvc.Controllers
{
    public class OrderPortionController : Controller
    {
        IOrder_PortionService _order_PortionService;

        public OrderPortionController(IOrder_PortionService order_PortionService)
        {
            _order_PortionService = order_PortionService;
        }


        public ActionResult Index()
        {

            var get = _order_PortionService.getAll().Data;
            return View(get);

        }



        [HttpPost]
        public IActionResult Add(Order_Portion order_Portion)
        {

            if (ModelState.IsValid)
            {

                var dataa = new Order_Portion
                {
                    orderPortionName = order_Portion.orderPortionName,
                   


                };
                var order_Portionresult = _order_PortionService.Add(dataa);
                if (order_Portionresult.Success)
                {

                    return RedirectToAction("Index", "OrderPortion");
                }
                else
                {
                    return RedirectToAction("Add", "OrderPortion");
                }


            }
            return View(order_Portion);
        }

        [HttpPost]
        public IActionResult Updated(Order_Portion order_Portion,int id)
        {

            var update = _order_PortionService.Update(order_Portion);
            var id2 = _order_PortionService.getById(id).Data;
            if (update.Success)
            {

                id2.id = order_Portion.id;
                id2.orderPortionName = order_Portion.orderPortionName.Trim();
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Deleted(int id)
        {

            var id2 = _order_PortionService.getById(id).Data;
            _order_PortionService.Delete(id2);
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
