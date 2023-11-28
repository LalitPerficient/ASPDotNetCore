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
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			ProductService productService = new ProductService();
			Products = productService.GetProducts();
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