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
			_db = db;
		}

		public async Task<bool> CreateAsync(Phone entity)
		{
			await _db.Phones.AddAsync(entity);
			await _db.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteAsync(Phone entity)
		{
			var en = _db.Phones.Remove(entity);
			await _db.SaveChangesAsync();

			if (en.State != EntityState.Deleted)
			{
				return false;
			}

			return true;
		}

		public async Task<Phone> GetAsync(int id)
		{
			return await _db.Phones.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<List<Phone>> GetAllAsync()
		{
			return await _db.Phones.ToListAsync();
		}

		public async Task<Phone> GetByNameAsync(string name)
		{
			return await _db.Phones.FirstOrDefaultAsync(p => p.Name == name);
		}

		public async Task<IEnumerable<Phone>> GetByOSAsync(TypeOperatingSystem typeOS)
		{
			return await Task.Run(
				() => _db.Phones.Where(p => p.TypeOperatingSystem == typeOS)
			);
		}

		public async Task<IEnumerable<Phone>> GetByPriceAsync(int minPrice, int maxPrice)
		{
			return await Task.Run(
				() => _db.Phones.Where(p => p.Price <= minPrice && p.Price >= maxPrice)
			); 
		}
	}
}
