using System.ComponentModel.DataAnnotations;

namespace PhoneMarket.Domain.Enum
{
	public enum TypeOperatingSystem
	{
		[Display(Name = "Android")]
		Android = 0,
		[Display(Name = "iOS")]
		iOS = 1,
		[Display(Name = "Other")]
		Other = 2
	}
}
