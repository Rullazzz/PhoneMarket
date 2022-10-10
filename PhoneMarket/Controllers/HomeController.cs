using Microsoft.AspNetCore.Mvc;
using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Enum;
using PhoneMarket.Models;
using System.Diagnostics;

namespace PhoneMarket.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var phone = new Phone()
			{
				Name = "Samsung A12",
				Model = "Smartphone",
				Price = 25000,
				TypeOperatingSystem = TypeOperatingSystem.Other
			};

			var phones = new List<Phone>()
			{
				phone
			};

			return View(phones);
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