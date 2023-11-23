using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeSync.Entities;
using SaudeSync.Persistense;

namespace SaudeSync.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly PostgreDbContext _context;

        public ConsultaController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            return _context.Consulta != null
                ? View(await _context.Consulta.ToListAsync())
                : Problem("Entity set 'PostgreDbContext.Consulta' is null.");
        }

        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consulta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Propriedade1,Propriedade2,Propriedade3")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Consulta {consulta.Id} cadastrada com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            return View(consulta);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return View(consulta);
        }

        // POST: Consulta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Propriedade1,Propriedade2,Propriedade3")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"Consulta {consulta.Id} atualizada com sucesso.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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
            return View(consulta);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consulta == null)
            {
                return Problem("Entity set 'PostgreDbContext.Consulta' is null.");
            }
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null)
            {
                _context.Consulta.Remove(consulta);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Cadastro excluído com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return (_context.Consulta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
