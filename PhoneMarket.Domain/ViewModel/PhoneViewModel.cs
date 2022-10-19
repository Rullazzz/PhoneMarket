namespace PhoneMarket.Domain.ViewModel
{
	public class PhoneViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

        public string Description { get; set; }

        public string TypePhone { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        public string TypeOperatingSystem { get; set; }
    }
}
