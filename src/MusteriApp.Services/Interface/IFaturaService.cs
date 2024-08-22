using MusteriApp.Data.Entities;

namespace MusteriApp.Services.Interface
{
    public interface IFaturaService
    {
        Task<IEnumerable<Fatura>> GetAllFaturalarAsync();
        Task<Fatura> GetFaturaByIdAsync(int id);
        Task AddFaturaAsync(Fatura fatura);
        Task UpdateFaturaAsync(Fatura fatura);
        Task DeleteFaturaAsync(int id);
        Task<IEnumerable<Fatura>> GetFaturalarByMusteriIdAsync(int musteriId);
        Task<(DateTime? Tarih, decimal? Borc)> GetMaxBorcByMusteriIdAsync(int musteriId);
    }
}
