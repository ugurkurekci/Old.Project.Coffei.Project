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
    public class TableController : ControllerBase
    {
        ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _tableService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _tableService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByTableNameId")]
        public IActionResult GetByTableNameId(int tableName)
        {
            var result = _tableService.GetByTableNameId(tableName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByTableLocationId")]
        public IActionResult GetByTableLocationId(int tableLocation)
        {
            var result = _tableService.GetByTableLocationId(tableLocation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByTableCapacity")]
        public IActionResult GetByTableCapacity(int tableCapacity)
        {
            var result = _tableService.GetByTableCapacity(tableCapacity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByIsActive")]
        public IActionResult GetByIsActive(bool IsActive)
        {
            var result = _tableService.GetByIsActive(IsActive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Table table)
        {
            var result = _tableService.Add(table);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Table table)
        {
            var result = _tableService.Update(table);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Table table)
        {
            var result = _tableService.Delete(table);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
    }
}
