using PhoneMarket.DAL.Interfaces;
using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Enum;
using PhoneMarket.Domain.Interfaces;
using PhoneMarket.Domain.Response;
using PhoneMarket.Service.Interfaces;

namespace PhoneMarket.Service.Implementations
{
	public class PhoneService : IPhoneService
	{
		private readonly IPhoneRepository _phoneRepository;

		public PhoneService(IPhoneRepository phoneRepository)
		{
			_phoneRepository = phoneRepository;
		}

		public async Task<IBaseResponse<IEnumerable<Phone>>> GetAllPhones()
		{
			var baseResponse = new BaseResponse<IEnumerable<Phone>>();

			try
			{
				var phones = await _phoneRepository.GetAllAsync();

				if (phones.Count == 0)
				{
					baseResponse.Description = "List phones is empty";
					baseResponse.StatusCode = StatusCode.OK;
					return baseResponse;
				}

				baseResponse.Data = phones;
				baseResponse.StatusCode = StatusCode.OK;

				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<IEnumerable<Phone>>()
				{
					Description = $"[GetAllAsync]: {ex.Message}"
				};
			}
		}
	}
}
