using Microsoft.AspNetCore.Mvc;
using PhoneMarket.Service.Interfaces;

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
			var response = await _phoneService.GetAllPhones();
			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
				return View(response);
			}
			return View("Error");
		}
	}
}
