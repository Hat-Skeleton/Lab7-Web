using L7_2.Models;

namespace L7_2.Repositories
{
    public interface IToyRepository
    {
        Task<List<Toy>> GetAll();
        Task<Toy> GetById(int id);
        Task Create(Toy toy);
        Task Update(Toy toy);
        Task Delete(int id);
    }
}
