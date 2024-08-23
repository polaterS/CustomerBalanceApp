using MusteriApp.Data.Entities;

namespace MusteriApp.Web.Models
{
    public class FaturaViewModel
    {
        public IEnumerable<Fatura> Faturalar { get; set; }
        public List<Musteri> Musteriler { get; set; }
        public List<int> SelectedMusteriIds { get; set; }
        public string Id { get; set; }
        public DateTime? FaturaTarihi { get; set; }
        public string FaturaTutari { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public Dictionary<int, int> MusteriFaturaSayisi { get; set; }
    }
}
