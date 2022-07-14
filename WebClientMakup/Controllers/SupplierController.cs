using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using WebClientMakup.Model;
using WebClientMakup.Models;

namespace WebClientMakup.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ILogger<SupplierController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int PageNumber)
        {
            if (PageNumber <= 0)
            {
                PageNumber = 1;
            }
            int PageSize = 10;

            //list = new List<Product>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7105/");
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/Supplier?PageNumber={PageNumber}&PageSize={PageSize}");

            //HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/Product?PageNumber={PageNumber}&PageSize={PageSize}");
            string json = await response.Content.ReadAsStringAsync();


            //var res =client.GetAsync("https://localhost:7105/api/product");
            var list = JsonConvert.DeserializeObject<PagedResponse<List<ProFileSupplier>>>(json);
            //PagedResponse<List<Product>> data = new PagedResponse<List<Product>>(list.Data,PageNumber, PageSize);

            return View(list);


            //return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> AddSupplier(string link, string name, string type)
        {

            //list = new List<Product>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7105/");

            ProFileSupplier supplier = new ProFileSupplier
            {
                SupplierName = name,
                Connection = link,
                Type = type,
            };
            var l  = JsonConvert.SerializeObject(supplier);

            var data = new StringContent(l, Encoding.UTF8, "application/json");


            var resp = await client.PostAsJsonAsync($"https://localhost:7105/api/Supplier?supplierJson={supplier}", supplier);


            JsonContent content = JsonContent.Create(l);

            //HttpResponseMessage response = await client.PostAsync($"https://localhost:7105/api/Supplier?supplierJson={content}", content);


            //StringContent content = new StringContent(l);
            // https://localhost:7105/api/Supplier?supplierJson=sssss
            //var cont = new StringContent(supplier.ToString());
            //HttpResponseMessage response = await client.PostAsync($"https://localhost:7105/api/Supplier?supplierJson={content}");

            //HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/Product?PageNumber={PageNumber}&PageSize={PageSize}");
            //string json = await response.Content.ReadAsStringAsync();


            //var res =client.GetAsync("https://localhost:7105/api/product");
            //var list = JsonConvert.DeserializeObject<PagedResponse<List<ProFileSupplier>>>(json);
            //PagedResponse<List<Product>> data = new PagedResponse<List<Product>>(list.Data,PageNumber, PageSize);

            //return View(list);


            return Ok();
        }


        //[HttpGet]
        //public async Task<IActionResult> Privacy(int PageNumber)
        //{
        //    if (PageNumber <= 0)
        //    {
        //        PageNumber = 1;
        //    }
        //    int PageSize = 10;

        //    //list = new List<Product>();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7105/");
        //    HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/Supplier?PageNumber={PageNumber}&PageSize={PageSize}");

        //    //HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/Product?PageNumber={PageNumber}&PageSize={PageSize}");
        //    string json = await response.Content.ReadAsStringAsync();


        //    //var res =client.GetAsync("https://localhost:7105/api/product");
        //    var list = JsonConvert.DeserializeObject<PagedResponse<List<SupplierController>>>(json);
        //    //PagedResponse<List<Product>> data = new PagedResponse<List<Product>>(list.Data,PageNumber, PageSize);

        //    return View(list);
        //}
        //public async Task<IActionResult> Details(string id)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7105/");
        //    HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/product/{id}");
        //    string json = await response.Content.ReadAsStringAsync();


        //    ////var res =client.GetAsync("https://localhost:7105/api/product");
        //    Product product = JsonConvert.DeserializeObject<Product>(json);
        //    //var product = list.Where(x => x.Id == id).FirstOrDefault();

        //    return PartialView("Details", product);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
