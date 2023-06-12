using L7_2.Models;

namespace L7_2.Repositories
{
    public interface IClothingRepository
    {
        Task<List<Clothing>> GetAll();
        Task<Clothing> GetById(int id);
        Task Create(Clothing clothing);
        Task Update(Clothing clothing);
        Task Delete(int id);
    }
}
