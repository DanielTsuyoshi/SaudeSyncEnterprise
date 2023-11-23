using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeSync.Entities;
using SaudeSync.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeSync.Controllers
{
    public class LeituraSaudeController : Controller
    {
        private readonly PostgreDbContext _context;

        public LeituraSaudeController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: LeituraSaude
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeituraSaude.ToListAsync());
        }

        // GET: LeituraSaude/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leituraSaude = await _context.LeituraSaude
                .FirstOrDefaultAsync(m => m.Id == id);

            if (leituraSaude == null)
            {
                return NotFound();
            }

            return View(leituraSaude);
        }

        // GET: LeituraSaude/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeituraSaude/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Propriedade1,Propriedade2")] LeituraSaude leituraSaude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leituraSaude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leituraSaude);
        }

        // GET: LeituraSaude/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leituraSaude = await _context.LeituraSaude.FindAsync(id);

            if (leituraSaude == null)
            {
                return NotFound();
            }

            return View(leituraSaude);
        }

        // POST: LeituraSaude/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Propriedade1,Propriedade2")] LeituraSaude leituraSaude)
        {
            if (id != leituraSaude.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leituraSaude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeituraSaudeExists(leituraSaude.Id))
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
            return View(leituraSaude);
        }

        // GET: LeituraSaude/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leituraSaude = await _context.LeituraSaude
                .FirstOrDefaultAsync(m => m.Id == id);

            if (leituraSaude == null)
            {
                return NotFound();
            }

            return View(leituraSaude);
        }

        // POST: LeituraSaude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leituraSaude = await _context.LeituraSaude.FindAsync(id);
            _context.LeituraSaude.Remove(leituraSaude);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeituraSaudeExists(int id)
        {
            return _context.LeituraSaude.Any(e => e.Id == id);
        }
    }
}
