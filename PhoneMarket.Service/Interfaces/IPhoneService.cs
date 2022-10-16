using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Interfaces;

namespace PhoneMarket.Service.Interfaces
{
	public interface IPhoneService
	{
		Task<IBaseResponse<IEnumerable<Phone>>> GetAllPhones();
	}
}
