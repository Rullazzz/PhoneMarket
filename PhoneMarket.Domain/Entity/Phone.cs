using PhoneMarket.Domain.Enum;

namespace PhoneMarket.Domain.Entity
{
    public class Phone
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        public TypeOperatingSystem TypeOperatingSystem { get; set; }
    }
}
