using Microsoft.AspNetCore.Mvc;
using ShoeWebApp.Data;
using ShoeWebApp.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ShoeWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            IList<ProductViewModel> models = new List<ProductViewModel>();
            ProductRepository productsRepository = new ProductRepository();
            var products = productsRepository.getAll();
            if(products != null)
            {
                models = products as IList<ProductViewModel>;
            }
            
            return View(models);
        }

        public async Task<IActionResult> EditProduct(int id) {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5266");
            string baseUrl = "/api/Product/GetById";
            string requestUrl = $"{baseUrl}/{id}";
            var response = await client.PostAsync(requestUrl,null);
            ProductViewModel products = new ProductViewModel();
            products = await response.Content.ReadFromJsonAsync<ProductViewModel>(); //productsRepository.getAll();

            return View(products);

        }

        public async Task<IActionResult> EditProductAction(ProductViewModel model) 
        {
            string jsonString = JsonSerializer.Serialize(model);


            //new StringContent(json, Encoding.UTF8, "application/json");
            //var jsonContent = JsonConvert.SerializeObject(model);
            


            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5266");
            //string baseUrl = "/api/Product/updateproduct";
            //string requestUrl = $"{baseUrl}";
            HttpHeaders header = new 

            
            HttpResponseMessage response = await client.PostAsync(
                "/api/Product/updateproduct",content );


            if (response.IsSuccessStatusCode)
            {

            }
            else
            {
                var returncontent = response.Content;
            }

            //var response = await client.PostAsync("/api/Product/updateproduct",Content);

            //string baseUrl2 = "/api/Product/GetById";
            //string requestUrl2 = $"{baseUrl2}/{model.ProductId}";
            //var response2 = await client.PostAsync(requestUrl2, null);
            //ProductViewModel products = new ProductViewModel();
            //products = await response2.Content.ReadFromJsonAsync<ProductViewModel>();

            return RedirectToAction("EditProduct");
        }
    }
}
