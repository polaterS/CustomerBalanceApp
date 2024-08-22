using Microsoft.AspNetCore.Mvc;
using MusteriApp.Data.Entities;
using MusteriApp.Services.Interface;

namespace MusteriApp.Web.Controllers
{
    public class MusteriController : Controller
    {
        private readonly IMusteriService _musteriService;

        public MusteriController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }

        public async Task<IActionResult> Index()
        {
            var musteriler = await _musteriService.GetAllMusterilerAsync();
            return View(musteriler);
        }

        public async Task<IActionResult> Details(int id)
        {
            var musteri = await _musteriService.GetMusteriByIdAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var musteri = await _musteriService.GetMusteriByIdAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Musteri musteri)
        {
            if (id != musteri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _musteriService.UpdateMusteriAsync(musteri);
                return RedirectToAction(nameof(Index));
            }
            return View(musteri);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var musteri = await _musteriService.GetMusteriByIdAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _musteriService.DeleteMusteriAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
