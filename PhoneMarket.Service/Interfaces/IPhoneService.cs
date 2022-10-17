using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Enum;
using PhoneMarket.Domain.Interfaces;
using PhoneMarket.Domain.ViewModel;

namespace PhoneMarket.Service.Interfaces
{
	public interface IPhoneService
	{
		Task<IBaseResponse<Phone>> CreateAsync(PhoneViewModel entity);

		Task<IBaseResponse<bool>> DeleteAsync(int id);

		Task<IBaseResponse<Phone>> GetAsync(int id);

		Task<IBaseResponse<Phone>> GetByNameAsync(string name);

		Task<IBaseResponse<IEnumerable<Phone>>> GetByOSAsync(TypeOperatingSystem typeOS);

		Task<IBaseResponse<IEnumerable<Phone>>> GetByPriceAsync(int minPrice, int maxPrice);

		Task<IBaseResponse<IEnumerable<Phone>>> GetAllPhonesAsync();
	}
}
