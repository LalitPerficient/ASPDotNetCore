using DeployOnVM.Models;
using DeployOnVM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeployOnVM.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public List<Product> Products;
		private readonly IProductService _productService;
		public HomeController(ILogger<HomeController> logger,IProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}

		public IActionResult Index()
		{
			Products = _productService.GetProducts();
			return View(Products);
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