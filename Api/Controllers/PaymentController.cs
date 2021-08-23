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
    public class PaymentController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var result = _paymentService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAllDetails")]
        public IActionResult getAllDetails()
        {
            var result = _paymentService.getAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByPaymentName")]
        public IActionResult getByPaymentName(int paymentName)
        {
            var result = _paymentService.getByPaymentName(paymentName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult getById(int id)
        {
            var result = _paymentService.getById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Payment payment)
        {
            var result = _paymentService.Update(payment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Payment payment)
        {
            var result = _paymentService.Delete(payment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
    }
}
