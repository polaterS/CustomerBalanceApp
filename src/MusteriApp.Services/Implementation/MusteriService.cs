using MusteriApp.Data.Entities;
using MusteriApp.Data.Repositories.Interface;
using MusteriApp.Services.Interface;

namespace MusteriApp.Services.Implementation
{
    public class MusteriService : IMusteriService
    {
        private readonly IMusteriRepository _musteriRepository;

        public MusteriService(IMusteriRepository musteriRepository)
        {
            _musteriRepository = musteriRepository;
        }

        public async Task<IEnumerable<Musteri>> GetAllMusterilerAsync()
        {
            return await _musteriRepository.GetAllAsync();
        }

        public async Task<Musteri> GetMusteriByIdAsync(int id)
        {
            return await _musteriRepository.GetByIdAsync(id);
        }

        public async Task AddMusteriAsync(Musteri musteri)
        {
            await _musteriRepository.AddAsync(musteri);
        }

        public async Task UpdateMusteriAsync(Musteri musteri)
        {
            await _musteriRepository.UpdateAsync(musteri);
        }

        public async Task DeleteMusteriAsync(int id)
        {
            await _musteriRepository.DeleteAsync(id);
        }

        public async Task<bool> MusteriExistsAsync(int id)
        {
            return await _musteriRepository.MusteriExistsAsync(id);
        }
    }
}
