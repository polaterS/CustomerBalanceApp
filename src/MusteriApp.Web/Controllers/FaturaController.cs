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

        public FaturaController(IFaturaService faturaService)
        {
            _faturaService = faturaService;
        }

        public async Task<IActionResult> Index(string id, string musteriId, string faturaTarihi, string faturaTutari, string odemeTarihi)
        {
            var faturalist = await _faturaService.GetAllFaturalarAsync();

            if (!string.IsNullOrEmpty(id))
            {
                faturalist = faturalist.Where(f => f.ID.ToString().Contains(id)).ToList();
            }

            if (!string.IsNullOrEmpty(musteriId))
            {
                faturalist = faturalist.Where(f => f.MUSTERI_ID.ToString().Contains(musteriId)).ToList();
            }

            if (!string.IsNullOrEmpty(faturaTarihi))
            {
                DateTime faturaDate;
                if (DateTime.TryParse(faturaTarihi, out faturaDate))
                {
                    faturalist = faturalist.Where(f => f.FATURA_TARIHI.Date == faturaDate.Date).ToList();
                }
            }

            if (!string.IsNullOrEmpty(faturaTutari))
            {
                faturalist = faturalist.Where(f => f.FATURA_TUTARI.ToString().Contains(faturaTutari)).ToList();
            }

            if (!string.IsNullOrEmpty(odemeTarihi))
            {
                DateTime odemeDate;
                if (DateTime.TryParse(odemeTarihi, out odemeDate))
                {
                    faturalist = faturalist.Where(f => f.ODEME_TARIHI.HasValue && f.ODEME_TARIHI.Value.Date == odemeDate.Date).ToList();
                }
            }

            return View(faturalist);
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
            var (tarih, borc) = await _faturaService.GetMaxBorcByMusteriIdAsync(musteriId);

            var model = new MaxBorcViewModel
            {
                MUSTERI_ID = musteriId,
                MaxBorcTarihi = tarih?.ToShortDateString(),
                MaxBorc = borc
            };

            return View(model);
        }
    }
}
