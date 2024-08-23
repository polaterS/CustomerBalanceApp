using Microsoft.AspNetCore.Mvc;
using MusteriApp.Data.Entities;
using MusteriApp.Services.Implementation;
using MusteriApp.Services.Interface;
using MusteriApp.Web.Models;

namespace MusteriApp.Web.Controllers
{
    public class FaturaController : Controller
    {
        private readonly IFaturaService _faturaService;
        private readonly IMusteriService _musteriService;

        public FaturaController(IFaturaService faturaService, IMusteriService musteriService)
        {
            _faturaService = faturaService;
            _musteriService = musteriService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var faturalist = await _faturaService.GetAllFaturalarAsync();
        //    var musteriler = await _musteriService.GetAllMusterilerAsync();

        //    var musteriFaturaSayisi = faturalist
        //        .GroupBy(f => f.MUSTERI_ID)
        //        .ToDictionary(g => g.Key, g => g.Count());

        //    var model = new FaturaViewModel
        //    {
        //        Musteriler = musteriler.ToList(),
        //        Faturalar = faturalist.ToList(),
        //        MusteriFaturaSayisi = musteriFaturaSayisi ?? new Dictionary<int, int>() 
        //    };



        //    return View(model);
        //}


        [HttpGet]
        public async Task<IActionResult> Index(FaturaViewModel model)
        {
            // Tüm faturaları ve müşterileri getir
            //var faturalar = await _faturaService.GetAllFaturalarAsync();
            //var musteriler = await _musteriService.GetAllMusterilerAsync();

            var faturalar = await _faturaService.GetAllFaturalarAsync();
            var musteriler = await _musteriService.GetAllMusterilerAsync();

            var musteriFaturaSayisi = faturalar
                .GroupBy(f => f.MUSTERI_ID)
                .ToDictionary(g => g.Key, g => g.Count());

            model.Musteriler = musteriler.ToList();
            model.Faturalar = faturalar.ToList();
            model.MusteriFaturaSayisi = musteriFaturaSayisi;

            // Filtreleme işlemleri
            if (!string.IsNullOrEmpty(model.Id))
            {
                faturalar = faturalar.Where(f => f.ID.ToString().Contains(model.Id));
            }

            if (model.SelectedMusteriIds != null && model.SelectedMusteriIds.Any())
            {
                faturalar = faturalar.Where(f => model.SelectedMusteriIds.Contains(f.MUSTERI_ID));
            }

            if (model.FaturaTarihi.HasValue)
            {
                faturalar = faturalar.Where(f => f.FATURA_TARIHI.Date == model.FaturaTarihi.Value.Date);
            }

            if (!string.IsNullOrEmpty(model.FaturaTutari))
            {
                if (decimal.TryParse(model.FaturaTutari, out decimal faturaTutarDecimal))
                {
                    faturalar = faturalar.Where(f => f.FATURA_TUTARI == faturaTutarDecimal);
                }
            }

            if (model.OdemeTarihi.HasValue)
            {
                faturalar = faturalar.Where(f => f.ODEME_TARIHI.HasValue && f.ODEME_TARIHI.Value.Date == model.OdemeTarihi.Value.Date);
            }

            // Modeli doldur
            model.Faturalar = faturalar.ToList();
            model.Musteriler = musteriler.ToList();

            return View(model);
        }




        public async Task<IActionResult> Details(int id)
        {
            var fatura = await _faturaService.GetFaturaByIdAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }
            return View(fatura);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var fatura = await _faturaService.GetFaturaByIdAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }
            return View(fatura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fatura fatura)
        {
            if (id != fatura.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _faturaService.UpdateFaturaAsync(fatura);
                return RedirectToAction(nameof(Index));
            }
            return View(fatura);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var fatura = await _faturaService.GetFaturaByIdAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }
            return View(fatura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _faturaService.DeleteFaturaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MaxBorc(int musteriId)
        {
            var faturalist = await _faturaService.GetFaturalarByMusteriIdAsync(musteriId);

            decimal? maxBorc = 0;
            DateTime? maxBorcTarihi = null;
            decimal currentBorc = 0;

            foreach (var fatura in faturalist.OrderBy(f => f.FATURA_TARIHI))
            {
                currentBorc += fatura.FATURA_TUTARI;

                if (fatura.ODEME_TARIHI.HasValue)
                {
                    currentBorc -= fatura.FATURA_TUTARI;
                }

                if (currentBorc > maxBorc)
                {
                    maxBorc = currentBorc;
                    maxBorcTarihi = fatura.FATURA_TARIHI;
                }
            }

            var model = new MaxBorcViewModel
            {
                MUSTERI_ID = musteriId,
                MaxBorcTarihi = maxBorcTarihi?.ToShortDateString(),
                MaxBorc = maxBorc
            };

            return View(model);
        }

    }
}
