using MusteriApp.Data.Entities;

namespace MusteriApp.Data.Repositories.Interface
{
    public interface IMusteriRepository
    {
        Task<IEnumerable<Musteri>> GetAllAsync();
        Task<Musteri> GetByIdAsync(int id);
        Task AddAsync(Musteri musteri);
        Task UpdateAsync(Musteri musteri);
        Task DeleteAsync(int id);
        Task<bool> MusteriExistsAsync(int id);
    }
}
