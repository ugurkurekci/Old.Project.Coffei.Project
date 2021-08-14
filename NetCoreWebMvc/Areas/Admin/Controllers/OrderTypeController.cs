using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebMvc.Controllers
{
    public class OrderTypeController : Controller
    {
        IOrder_TypeService _order_TypeService;

        public OrderTypeController(IOrder_TypeService order_TypeService)
        {
            _order_TypeService = order_TypeService;
        }

        public ActionResult Index()
        {

            var get = _order_TypeService.GetAll().Data;
            return View(get);

        }



        [HttpPost]
        public IActionResult Add(Order_Type order_Type)
        {

            if (ModelState.IsValid)
            {

                var dataa = new Order_Type
                {
                    orderTypeName = order_Type.orderTypeName,



                };
                var order_Typeresult = _order_TypeService.Add(dataa);
                if (order_Typeresult.Success)
                {

                    return RedirectToAction("Index", "OrderType");
                }
                else
                {
                    return RedirectToAction("Add", "OrderType");
                }


            }
            return View(order_Type);
        }

        [HttpPost]
        public IActionResult Updated(Order_Type order_Type, int id)
        {

            var update = _order_TypeService.Update(order_Type);
            var id2 = _order_TypeService.GetByid(id).Data;
            if (update.Success)
            {

                id2.id = order_Type.id;
                id2.orderTypeName = order_Type.orderTypeName.Trim();
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Deleted(int id)
        {

            var id2 = _order_TypeService.GetByid(id).Data;
            _order_TypeService.Delete(id2);
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


