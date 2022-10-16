using Microsoft.AspNetCore.Mvc;
using PhoneMarket.DAL.Interfaces;
using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Enum;
using PhoneMarket.Models;
using System.Diagnostics;

namespace PhoneMarket.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IPhoneRepository _phoneRepository;

		public HomeController(ILogger<HomeController> logger, IPhoneRepository phoneRepository) 
		{
			_logger = logger;
			_phoneRepository = phoneRepository;
		}

		public async Task<IActionResult> Index()
		{
			var phones = await _phoneRepository.GetAllAsync();

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