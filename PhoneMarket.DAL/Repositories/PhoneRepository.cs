using Microsoft.EntityFrameworkCore;
using PhoneMarket.DAL.Interfaces;
using PhoneMarket.Domain.Entity;
using PhoneMarket.Domain.Enum;

namespace PhoneMarket.DAL.Repositories
{
	public class PhoneRepository : IPhoneRepository
	{
		private readonly ApplicationDbContext _db;

		public PhoneRepository(ApplicationDbContext db)
		{
			_db = db ?? throw new ArgumentNullException(nameof(db));
		}

		public bool Create(Phone entity)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Phone entity)
		{
			throw new NotImplementedException();
		}

		public Phone Get(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Phone>> GetAllAsync()
		{
			return await _db.Phones.ToListAsync();
		}

		public Phone GetByName(string name)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Phone> GetByOS(TypeOperatingSystem typeOS)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Phone> GetByPrice(int minPrice, int maxPrice)
		{
			throw new NotImplementedException();
		}
	}
}
