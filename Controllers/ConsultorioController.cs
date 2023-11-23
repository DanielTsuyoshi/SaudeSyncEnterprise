using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeSync.Entities;
using SaudeSync.Persistense;

namespace SaudeSync.Controllers
{
    public class ConsultorioController : Controller
    {
        private readonly PostgreDbContext _context;

        public ConsultorioController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: Consultorio
        public async Task<IActionResult> Index()
        {
            return _context.Consultorio != null
                ? View(await _context.Consultorio.ToListAsync())
                : Problem("Entity set 'PostgreDbContext.Consultorio' is null.");
        }

        // GET: Consultorio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // GET: Consultorio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultorio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Propriedade1,Propriedade2,Propriedade3")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultorio);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Consultorio {consultorio.Id} cadastrado com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            return View(consultorio);
        }

        // GET: Consultorio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio.FindAsync(id);
            if (consultorio == null)
            {
                return NotFound();
            }
            return View(consultorio);
        }

        // POST: Consultorio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Propriedade1,Propriedade2,Propriedade3")] Consultorio consultorio)
        {
            if (id != consultorio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultorio);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"Consultorio {consultorio.Id} atualizado com sucesso.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultorioExists(consultorio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(consultorio);
        }

        // GET: Consultorio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // POST: Consultorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consultorio == null)
            {
                return Problem("Entity set 'PostgreDbContext.Consultorio' is null.");
            }
            var consultorio = await _context.Consultorio.FindAsync(id);
            if (consultorio != null)
            {
                _context.Consultorio.Remove(consultorio);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Cadastro excluído com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        private bool ConsultorioExists(int id)
        {
            return (_context.Consultorio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
