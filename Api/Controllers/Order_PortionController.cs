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
    public class Order_PortionController : ControllerBase
    {
        IOrder_PortionService _order_PortionService;

        public Order_PortionController(IOrder_PortionService order_PortionService)
        {
            _order_PortionService = order_PortionService;
        }

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var result = _order_PortionService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Order_Portion order_Portion)
        {
            var result = _order_PortionService.Add(order_Portion);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Order_Portion order_Portion)
        {
            var result = _order_PortionService.Update(order_Portion);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Order_Portion order_Portion)
        {
            var result = _order_PortionService.Delete(order_Portion);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }

    }
}
