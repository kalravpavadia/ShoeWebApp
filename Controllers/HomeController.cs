using Microsoft.AspNetCore.Mvc;
using ShoeWebApp.Data;
using ShoeWebApp.Models;
using System.Diagnostics;

namespace ShoeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5266");

            var response = await client.GetAsync("/api/Product/Getproducts");
            IList<ProductViewModel> products = new List<ProductViewModel>();
            products = await response.Content.ReadFromJsonAsync<IList<ProductViewModel>>(); //productsRepository.getAll();
            
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
