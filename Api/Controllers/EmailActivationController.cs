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
    public class EmailActivationController : ControllerBase
    {
        IEmail_ActivationService _email_ActivationService;

        public EmailActivationController(IEmail_ActivationService email_ActivationService)
        {
            _email_ActivationService = email_ActivationService;
        }

        [HttpPost("add")]
        public IActionResult Add(Email_Activation email,string mail)
        {
            var result = _email_ActivationService.Add(email,mail);
            if (result==null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
