using Microsoft.AspNetCore.Mvc;
using PhoneMarket.Models;
using PhoneMarket.Service.Interfaces;
using System.Diagnostics;

namespace PhoneMarket.Controllers
{
	public class PhoneController : Controller
	{
		private readonly IPhoneService _phoneService;

		public PhoneController(IPhoneService phoneService)
		{
			_phoneService = phoneService;
		}

		[HttpGet]
		public async Task<IActionResult> GetPhones()
		{
			var response = await _phoneService.GetAllPhonesAsync();
			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
				return View(response.Data);
			}
			return RedirectToAction("Error");
		}

		[HttpGet]
		public async Task<IActionResult> GetPhone(int id)
		{
			var response = await _phoneService.GetAsync(id);
			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
				return View(response.Data);
			}
			return Redirect("Error");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
