using PhoneMarket.DAL.Interfaces;
using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Enum;
using PhoneMarket.Domain.Interfaces;
using PhoneMarket.Domain.Response;
using PhoneMarket.Domain.ViewModel;
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

		public async Task<IBaseResponse<Phone>> CreateAsync(PhoneViewModel entity)
		{
			var baseResponse = new BaseResponse<Phone>();

			try
			{
				var phone = new Phone()
				{
					DateCreate = DateTime.Now,
					Name = entity.Name,
					Price = entity.Price,
					TypePhone = entity.TypePhone,
					Description = entity.Description,
					TypeOperatingSystem = (TypeOperatingSystem)Convert.ToInt32(entity.TypeOperatingSystem)
				};

				await _phoneRepository.CreateAsync(phone);

				baseResponse.Data = phone;
				baseResponse.StatusCode = StatusCode.OK;

				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Phone>()
				{
					Description = $"[CreateAsync]: {ex.Message}"
				};
			}
		}

		public async Task<IBaseResponse<bool>> DeleteAsync(int id)
		{
			var baseResponse = new BaseResponse<bool>()
			{
				Data = false
			};

			try
			{
				var phone = await _phoneRepository.GetAsync(id);

				if (phone == null)
				{
					baseResponse.Description = "There is no phone with this id";
					baseResponse.StatusCode = StatusCode.NoData;
					return baseResponse;
				}

				await _phoneRepository.DeleteAsync(phone);

				baseResponse.Data = true;

				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[DeleteAsync]: {ex.Message}"
				};
			}
		}

		public async Task<IBaseResponse<IEnumerable<Phone>>> GetAllPhonesAsync()
		{
			var baseResponse = new BaseResponse<IEnumerable<Phone>>();

			try
			{
				var phones = await _phoneRepository.GetAllAsync();

				if (phones.Count == 0)
				{
					baseResponse.Description = "List phones is empty";
					baseResponse.StatusCode = StatusCode.NoData;
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
					Description = $"[GetAllPhonesAsync]: {ex.Message}"
				};
			}
		}

		public async Task<IBaseResponse<Phone>> GetAsync(int id)
		{
			var baseResponse = new BaseResponse<Phone>();

			try
			{
				var phone = await _phoneRepository.GetAsync(id);

				if (phone == null)
				{
					baseResponse.Description = "There is no phone with this id";
					baseResponse.StatusCode = StatusCode.NoData;
					return baseResponse;
				}

				baseResponse.Data = phone;
				baseResponse.StatusCode = StatusCode.OK;

				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Phone>()
				{
					Description = $"[GetAsync]: {ex.Message}"
				};
			}
		}

		public async Task<IBaseResponse<Phone>> GetByNameAsync(string name)
		{
			var baseResponse = new BaseResponse<Phone>();

			try
			{
				var phone = await _phoneRepository.GetByNameAsync(name);

				if (phone == null)
				{
					baseResponse.Description = "There is no phone with this name";
					baseResponse.StatusCode = StatusCode.NoData;
					return baseResponse;
				}

				baseResponse.Data = phone;
				baseResponse.StatusCode = StatusCode.OK;

				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Phone>()
				{
					Description = $"[GetByNameAsync]: {ex.Message}"
				};
			}
		}

		public async Task<IBaseResponse<IEnumerable<Phone>>> GetByOSAsync(TypeOperatingSystem typeOS)
		{
			var baseResponse = new BaseResponse<IEnumerable<Phone>>();

			try
			{
				var phones = await _phoneRepository.GetByOSAsync(typeOS);

				if (phones == null)
				{
					baseResponse.Description = "There are no phones with this OS";
					baseResponse.StatusCode = StatusCode.NoData;
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
					Description = $"[GetByOSAsync]: {ex.Message}"
				};
			}
		}

		public async Task<IBaseResponse<IEnumerable<Phone>>> GetByPriceAsync(int minPrice, int maxPrice)
		{
			var baseResponse = new BaseResponse<IEnumerable<Phone>>();

			try
			{
				var phones = await _phoneRepository.GetByPriceAsync(minPrice, maxPrice);

				if (phones == null)
				{
					baseResponse.Description = "There are no phones with this price";
					baseResponse.StatusCode = StatusCode.NoData;
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
					Description = $"[GetByPriceAsync]: {ex.Message}"
				};
			}
		}
	}
}
