using DeployOnVM.Models;
using DeployOnVM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeployOnVM.Controllers
{
    
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IProductService _productService;
		public HomeController(ILogger<HomeController> logger,IProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}

		public IActionResult Index()
		{
			ProductResponse productResponse = new ProductResponse()
			{
				IsBeta = _productService.IsBeta().Result,
				Products = _productService.GetProducts()
			};

			return View(productResponse);
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