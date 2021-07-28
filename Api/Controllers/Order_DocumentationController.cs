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

        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            var result = _order_DocumentationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallDetails")]
        public IActionResult getallDetails()
        {
            var result = _order_DocumentationService.GetAllDetails();
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
