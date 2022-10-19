using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneMarket.Domain.ViewModel;
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

			return RedirectToAction("Error");

		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var response = await _phoneService.DeleteAsync(id);
			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
				return RedirectToAction("GetPhones");
			}

			return RedirectToAction("Error");
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Save(int id)
		{
			if (id == 0)
			{
				return View();
			}

			var response = await _phoneService.GetAsync(id);
			if (response.StatusCode == Domain.Enum.StatusCode.OK)
			{
				return View(response.Data);
			}

			return RedirectToAction("Error");
		}

		[HttpPost]
		public async Task<IActionResult> Save(PhoneViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (model.Id == 0)
				{
					await _phoneService.CreateAsync(model);
				}
				else
				{
					await _phoneService.EditAsync(model.Id, model);
				}
			}

			return RedirectToAction("GetPhones");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
