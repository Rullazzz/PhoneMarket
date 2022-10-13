namespace PhoneMarket.DAL.Interfaces
{
	public interface IBaseRepository<T>
	{
		bool Create(T entity);

		T Get(int id);

		Task<List<T>> GetAllAsync();

		bool Delete(T entity);
	}
}
