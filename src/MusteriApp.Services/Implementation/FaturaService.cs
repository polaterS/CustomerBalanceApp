using Microsoft.EntityFrameworkCore;
using MusteriApp.Data;
using MusteriApp.Data.Entities;
using MusteriApp.Data.Repositories.Interface;
using MusteriApp.Services.Interface;

namespace MusteriApp.Services.Implementation
{
    public class FaturaService : IFaturaService
    {
        private readonly IFaturaRepository _faturaRepository;
        private readonly MusteriAppContext _context;

        public FaturaService(IFaturaRepository faturaRepository, MusteriAppContext context)
        {
            _faturaRepository = faturaRepository;
            _context = context;
        }

        public async Task<IEnumerable<Fatura>> GetAllFaturalarAsync()
        {
            return await _faturaRepository.GetAllAsync();
        }

        public async Task<Fatura> GetFaturaByIdAsync(int id)
        {
            return await _faturaRepository.GetByIdAsync(id);
        }

        public async Task AddFaturaAsync(Fatura fatura)
        {
            await _faturaRepository.AddAsync(fatura);
        }

        public async Task UpdateFaturaAsync(Fatura fatura)
        {
            await _faturaRepository.UpdateAsync(fatura);
        }

        public async Task DeleteFaturaAsync(int id)
        {
            await _faturaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Fatura>> GetFaturalarByMusteriIdAsync(int musteriId)
        {
            return await _faturaRepository.GetFaturalarByMusteriIdAsync(musteriId);
        }

        public async Task<(DateTime? Tarih, decimal? Borc)> GetMaxBorcByMusteriIdAsync(int musteriId)
        {
            var maxBorcData = await _context.Faturalar
                                            .Where(f => f.MUSTERI_ID == musteriId)
                                            .OrderByDescending(f => f.FATURA_TUTARI)
                                            .FirstOrDefaultAsync();

            if (maxBorcData == null)
                return (null, null);

            return (maxBorcData.FATURA_TARIHI, maxBorcData.FATURA_TUTARI);
        }
    }
}
