using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebClientMakup.Model;
using WebClientMakup.Models;
using WebClientMakup.Services;

namespace WebClientMakup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private IFormFile formFile;
        public async Task<IActionResult> Index(string supplierName, IFormFile file)
        {
            if (file != null)
            {
                FileInfo fileInfo = new FileInfo(file.FileName);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7105/");      
                using var requestContext = new MultipartFormDataContent();
                var fileStream = file.OpenReadStream();
                requestContext.Add(new StreamContent(fileStream), "file", file.FileName);
                await client.PostAsync($"https://localhost:7105/api/product/{supplierName}", requestContext);
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("https://localhost:7105/");
                HttpResponseMessage response = await client1.GetAsync($"https://localhost:7105/api/Supplier/{supplierName}");
                string json = await response.Content.ReadAsStringAsync();
                var supplier = JsonConvert.DeserializeObject<ProFileSupplier>(json);

                return View(supplier);
            }
            else
            {
                if (supplierName != null)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:7105/");
                    HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/Supplier/{supplierName}");
                    string json = await response.Content.ReadAsStringAsync();
                    var supplier = JsonConvert.DeserializeObject<ProFileSupplier>(json);
                    if (supplier != null)
                    {
                        return View(supplier);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }


        }

        [HttpPost]
        public async void Upload(string supplier, IFormFile file)
        {
            var s = file.OpenReadStream().ToString();
            FileInfo fileInfo = new FileInfo(file.FileName);
            using (FileStream stream = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), file.FileName), FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    ViewBag.Res = await reader.ReadToEndAsync();
                }
            }
        }

        public async Task<IActionResult> UploadToBase(string supplierName, IFormFile file)
        {
            file = formFile;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7105/");

            using var requestContext = new MultipartFormDataContent();
            var fileStream = System.IO.File.OpenRead(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), file.FileName));
            requestContext.Add(new StreamContent(fileStream),"file", file.FileName);
            await client.PostAsync($"https://localhost:7105/api/product/{supplierName}", requestContext);


            //HttpResponseMessage response = await client.PostAsync($"https://localhost:7105/api/product/{supplierName}");
            //string json = await response.Content.ReadAsStringAsync();

            //var supplier = JsonConvert.DeserializeObject<ProFileSupplier>(json);
            //if (supplier != null)
            //{
            return RedirectToAction("Index","Home");
            //}
            //else
            //{
            //    return View();
            //}
            //return View();
        }


        [HttpGet]
        public async Task<IActionResult> Privacy(int PageNumber)
        {
            if (PageNumber <= 0)
            {
                PageNumber = 1;
            }
            int PageSize = 10;

            //list = new List<Product>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7105/");
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/Product?PageNumber={PageNumber}&PageSize={PageSize}"); 
            string json = await response.Content.ReadAsStringAsync();
          

            //var res =client.GetAsync("https://localhost:7105/api/product");
            var list = JsonConvert.DeserializeObject<PagedResponse<List<Product>>>(json);
            //PagedResponse<List<Product>> data = new PagedResponse<List<Product>>(list.Data,PageNumber, PageSize);

            return View(list);
        }
        public async Task<IActionResult> Details(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7105/");
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7105/api/product/{id}");
            string json = await response.Content.ReadAsStringAsync();


            ////var res =client.GetAsync("https://localhost:7105/api/product");
            Product product = JsonConvert.DeserializeObject<Product>(json);
            //var product = list.Where(x => x.Id == id).FirstOrDefault();

            return PartialView("Details",product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}