using KPMG.Interview.TaskOne.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KPMG.Interview.TaskOne.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration; 
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await httpClient.GetFromJsonAsync<string>(configuration["ApiUrl"]);

            var homeViewModel = new HomeViewModel()
            {
                WebApiData = response,
                WebAppData = "Hello From WebApp."
            };

            return View(homeViewModel);
        }
    }
}