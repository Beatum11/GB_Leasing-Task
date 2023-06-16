using api.Models;

namespace api.Interfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> GetByName(string name);

        Task<T> CreateItem(T item);

        Task UpdateItem(T item);

        Task DeleteById(int id);
    }
}
