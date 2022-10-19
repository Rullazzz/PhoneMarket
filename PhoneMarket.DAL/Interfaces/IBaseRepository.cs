namespace PhoneMarket.DAL.Interfaces
{
	public interface IBaseRepository<T>
	{
		Task<bool> CreateAsync(T entity);

		Task<T> GetAsync(int id);

		Task<List<T>> GetAllAsync();

		Task<bool> DeleteAsync(T entity);

		Task<T> Update(T entity);
	}
}
