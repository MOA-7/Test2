namespace Test2.Contract
{
    public interface IgenricRepostory<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GettAll();
        Task<T> AddAsync(T entity);

        Task<bool> Exist(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync (T entity);
    }
}
