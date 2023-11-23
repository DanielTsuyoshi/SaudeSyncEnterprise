using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeSync.Entities;
using SaudeSync.Persistense;

namespace SaudeSync.Controllers
{
    public class PrescricaoController : Controller
    {
        private readonly PostgreDbContext _context;

        public PrescricaoController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: Prescricao
        public async Task<IActionResult> Index()
        {
            return _context.Prescricao != null
                ? View(await _context.Prescricao.ToListAsync())
                : Problem("Entity set 'PostgreDbContext.Prescricao' is null.");
        }

        // GET: Prescricao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prescricao == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescricao == null)
            {
                return NotFound();
            }

            return View(prescricao);
        }

        // GET: Prescricao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prescricao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Propriedade1,Propriedade2,Propriedade3")] Prescricao prescricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescricao);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Prescrição {prescricao.Id} cadastrada com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            return View(prescricao);
        }

        // GET: Prescricao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prescricao == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricao.FindAsync(id);
            if (prescricao == null)
            {
                return NotFound();
            }
            return View(prescricao);
        }

        // POST: Prescricao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Propriedade1,Propriedade2,Propriedade3")] Prescricao prescricao)
        {
            if (id != prescricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescricao);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"Prescrição {prescricao.Id} atualizada com sucesso.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescricaoExists(prescricao.Id))
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
            return View(prescricao);
        }

        // GET: Prescricao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prescricao == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescricao == null)
            {
                return NotFound();
            }

            return View(prescricao);
        }

        // POST: Prescricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prescricao == null)
            {
                return Problem("Entity set 'PostgreDbContext.Prescricao' is null.");
            }
            var prescricao = await _context.Prescricao.FindAsync(id);
            if (prescricao != null)
            {
                _context.Prescricao.Remove(prescricao);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Cadastro excluído com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        private bool PrescricaoExists(int id)
        {
            return (_context.Prescricao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
