using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_TypeController : ControllerBase
    {
        IOrder_TypeService _order_TypeService;

        public Order_TypeController(IOrder_TypeService order_TypeService)
        {
            _order_TypeService = order_TypeService;
        }

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var result = _order_TypeService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Order_Type order_Type)
        {
            var result = _order_TypeService.Add(order_Type);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Order_Type order_Type)
        {
            var result = _order_TypeService.Update(order_Type);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Order_Type order_Type)
        {
            var result = _order_TypeService.Delete(order_Type);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
    }
}
