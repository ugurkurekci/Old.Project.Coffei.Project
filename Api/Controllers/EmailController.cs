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
    public class EmailController : ControllerBase
    {
        IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _emailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Email email)
        {
            var result = _emailService.Add(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Email email)
        {
            var result = _emailService.Update(email);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Email email)
        {
            var result = _emailService.Delete(email);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }

    }
}
