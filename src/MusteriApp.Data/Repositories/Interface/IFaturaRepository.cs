using MusteriApp.Data.Entities;

namespace MusteriApp.Data.Repositories.Interface
{
    public interface IFaturaRepository
    {
        Task<IEnumerable<Fatura>> GetAllAsync();
        Task<Fatura> GetByIdAsync(int id);
        Task AddAsync(Fatura fatura);
        Task UpdateAsync(Fatura fatura);
        Task DeleteAsync(int id);
        Task<IEnumerable<Fatura>> GetFaturalarByMusteriIdAsync(int musteriId);
        Task<decimal> GetMaxBorcByMusteriIdAsync(int musteriId);
    }
}
