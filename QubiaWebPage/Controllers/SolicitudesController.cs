using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QubiaWebPage.Models;

namespace QubiaWebPage.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly QubiaDbContext _context;

        public SolicitudesController(QubiaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var solicitude = await _context.Solicitudes.ToListAsync();
            return View(solicitude);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var solicitude = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (solicitude == null)
                return NotFound();

            return View(solicitude);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Solicitude solicitude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitude);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var solicitude = await _context.Solicitudes.FindAsync(id);
            if (solicitude == null)
                return NotFound();

            return View(solicitude);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Solicitude solicitude)
        {
            if (id != solicitude.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudeExists(solicitude.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(solicitude);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var solicitude = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (solicitude == null)
                return NotFound();

            return View(solicitude);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitude = await _context.Solicitudes.FindAsync(id);
            if (solicitude != null)
            {
                _context.Solicitudes.Remove(solicitude);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudeExists(int id)
        {
            return _context.Solicitudes.Any(e => e.Id == id);
        }
    }
}

