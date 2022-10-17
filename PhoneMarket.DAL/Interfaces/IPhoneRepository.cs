using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Enum;

namespace PhoneMarket.DAL.Interfaces
{
	public interface IPhoneRepository : IBaseRepository<Phone>
	{
		Task<Phone> GetByNameAsync(string name);

		Task<IEnumerable<Phone>> GetByOSAsync(TypeOperatingSystem typeOS);

		Task<IEnumerable<Phone>> GetByPriceAsync(int minPrice, int maxPrice);
	}
}
