using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Enum;

namespace PhoneMarket.DAL.Interfaces
{
	public interface IPhoneRepository : IBaseRepository<Phone>
	{
		Phone GetByName(string name);

		IEnumerable<Phone> GetByOS(TypeOperatingSystem typeOS);

		IEnumerable<Phone> GetByPrice(int minPrice, int maxPrice);
	}
}
