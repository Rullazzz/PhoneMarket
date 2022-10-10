using Microsoft.EntityFrameworkCore;
using PhoneMarket.Domain.Entity;

namespace PhoneMarket.DAL
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
		{
			Database.EnsureCreated();
		}

		public DbSet<Phone> Phones { get; set; } = null!;
	}
}
