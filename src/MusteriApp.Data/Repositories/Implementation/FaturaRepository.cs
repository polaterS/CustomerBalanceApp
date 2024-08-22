using Microsoft.EntityFrameworkCore;
using MusteriApp.Data.Entities;
using MusteriApp.Data.Repositories.Interface;

namespace MusteriApp.Data.Repositories.Implementation
{
    public class FaturaRepository : IFaturaRepository
    {
        private readonly MusteriAppContext _context;

        public FaturaRepository(MusteriAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fatura>> GetAllAsync()
        {
            return await _context.Faturalar.Include(f => f.Musteri).ToListAsync();
        }

        public async Task<Fatura> GetByIdAsync(int id)
        {
            return await _context.Faturalar.FindAsync(id);
        }

        public async Task AddAsync(Fatura fatura)
        {
            await _context.Faturalar.AddAsync(fatura);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fatura fatura)
        {
            _context.Faturalar.Update(fatura);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fatura = await _context.Faturalar.FindAsync(id);
            if (fatura != null)
            {
                _context.Faturalar.Remove(fatura);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Fatura>> GetFaturalarByMusteriIdAsync(int musteriId)
        {
            return await _context.Faturalar
                .Where(f => f.MUSTERI_ID == musteriId)
                .Include(f => f.Musteri)
                .ToListAsync();
        }

        public async Task<decimal> GetMaxBorcByMusteriIdAsync(int musteriId)
        {
            return await _context.Faturalar
                .Where(f => f.MUSTERI_ID == musteriId)
                .MaxAsync(f => f.FATURA_TUTARI);
        }
    }
}
