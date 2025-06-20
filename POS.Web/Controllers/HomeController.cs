using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Web.Models;
using POS.Web.Services;

namespace POS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DapperServices _dapperServices;
        public HomeController(ILogger<HomeController> logger, DapperServices dapperservices)
        {
            _logger = logger;
            _dapperServices = dapperservices;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dapperServices.GetProjectsAsync(); 
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
