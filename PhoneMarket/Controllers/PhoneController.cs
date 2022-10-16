using Microsoft.AspNetCore.Mvc;
using PhoneMarket.DAL.Interfaces;
using PhoneMarket.Domain.Entity;

namespace PhoneMarket.Controllers
{
	public class PhoneController : Controller
	{
		private readonly IPhoneRepository _phoneRepository;

		public PhoneController(IPhoneRepository phoneRepository)
		{
			_phoneRepository = phoneRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetPhones()
		{
			var response = await _phoneRepository.GetAllAsync();

			return View(response);
		}
	}
}
