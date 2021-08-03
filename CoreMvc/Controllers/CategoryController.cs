using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace CoreMvc.Controllers
{
    public class CategoryController : Controller
    {
        #region defines
        private HttpClient _httpClient;
        private string url = "https://localhost:5001/api/";
        #endregion defines
        #region constructor
        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion constructor
        public IActionResult Index()
        {
            var categoryes = _httpClient.GetFromJsonAsync<List<Category>>(url + "Category/getall");
            return View();
        }
    }
}
