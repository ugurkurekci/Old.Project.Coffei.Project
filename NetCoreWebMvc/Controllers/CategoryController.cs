using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NetCoreWebMvc.Controllers
{
    public class CategoryController : Controller
    {
        private HttpClient _httpClient;
        private ICategoryService _categoryService;

        public CategoryController(HttpClient httpClient, ICategoryService categoryService)
        {
            _httpClient = httpClient;
            _categoryService = categoryService;
        }
        private string url = "https://localhost:5001/api/";
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _httpClient.GetFromJsonAsync<List<Category>>(url + "Category/GetAll");
            return View(result);
        }
    }
}
