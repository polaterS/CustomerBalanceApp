using Microsoft.EntityFrameworkCore;
using MusteriApp.Data.Entities;
using MusteriApp.Data.Repositories.Interface;

namespace MusteriApp.Data.Repositories.Implementation
{
    public class MusteriRepository : IMusteriRepository
    {
        private readonly MusteriAppContext _context;

        public MusteriRepository(MusteriAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Musteri>> GetAllAsync()
        {
            return await _context.Musteriler.ToListAsync();
        }

        public async Task<Musteri> GetByIdAsync(int id)
        {
            return await _context.Musteriler.FindAsync(id);
        }

        public async Task AddAsync(Musteri musteri)
        {
            await _context.Musteriler.AddAsync(musteri);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Musteri musteri)
        {
            _context.Musteriler.Update(musteri);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);
            if (musteri != null)
            {
                _context.Musteriler.Remove(musteri);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> MusteriExistsAsync(int id)
        {
            return await _context.Musteriler.AnyAsync(m => m.ID == id);
        }
    }
}
