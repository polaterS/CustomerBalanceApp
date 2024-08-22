using MusteriApp.Data.Entities;

namespace MusteriApp.Services.Interface
{
    public interface IMusteriService
    {
        Task<IEnumerable<Musteri>> GetAllMusterilerAsync();
        Task<Musteri> GetMusteriByIdAsync(int id);
        Task AddMusteriAsync(Musteri musteri);
        Task UpdateMusteriAsync(Musteri musteri);
        Task DeleteMusteriAsync(int id);
        Task<bool> MusteriExistsAsync(int id);
    }
}
