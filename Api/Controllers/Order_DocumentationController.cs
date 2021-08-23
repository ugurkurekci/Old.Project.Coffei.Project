using Business.Abstract;
using Entities;
using Entities.Dtos;
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
    public class Order_DocumentationController : ControllerBase
    {
        IOrder_DocumentationService _order_DocumentationService;

        public Order_DocumentationController(IOrder_DocumentationService order_DocumentationService)
        {
            _order_DocumentationService = order_DocumentationService;
        }

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var result = _order_DocumentationService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAllDetails")]
        public IActionResult getAllDetails()
        {
            var result = _order_DocumentationService.getAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult add(Order_Documentation order_Documentation)
        {
            var result = _order_DocumentationService.Add(order_Documentation);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }

        

    }
}
