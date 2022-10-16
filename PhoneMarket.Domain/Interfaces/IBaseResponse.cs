using PhoneMarket.Domain.Enum;

namespace PhoneMarket.Domain.Interfaces
{
	public interface IBaseResponse<T>
	{
		StatusCode StatusCode { get; set; }

		T Data { get; }
	}
}
