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
        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var result = _tableService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAllDetails")]
        public IActionResult getAllDetails()
        {
            var result = _tableService.getAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByTableNameId")]
        public IActionResult getByTableNameId(int tableName)
        {
            var result = _tableService.getByTableNameId(tableName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByTableLocationId")]
        public IActionResult getByTableLocationId(int tableLocation)
        {
            var result = _tableService.getByTableLocationId(tableLocation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByTableCapacity")]
        public IActionResult getByTableCapacity(int tableCapacity)
        {
            var result = _tableService.getByTableCapacity(tableCapacity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByIsActive")]
        public IActionResult getByIsActive(bool IsActive)
        {
            var result = _tableService.getByIsActive(IsActive);
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
