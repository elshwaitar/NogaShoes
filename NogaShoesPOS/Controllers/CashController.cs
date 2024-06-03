using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NogaShoesPOS.Models;
using System.Linq;
using System.Threading.Tasks;

namespace POSSystem.Controllers
    {
    public class CashController : Controller
        {
        private readonly POSDbContext _context;

        public CashController(POSDbContext context)
            {
            _context = context;
            }

        public async Task<IActionResult> Index()
            {
            return View(await _context.Cashes.ToListAsync());
            }

        public IActionResult Create()
            {
            return View();
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,Cashier,Date,Amount,Description")] Cash cash)
            {
            if (ModelState.IsValid)
                {
                _context.Add(cash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            return View(cash);
            }

        public async Task<IActionResult> Edit(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var cash = await _context.Cashes.FindAsync(id);
            if (cash == null)
                {
                return NotFound();
                }
            return View(cash);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,CustomerName,Cashier,Description")] Cash cash)
            {
            if (id != cash.Id)
                {
                return NotFound();
                }

            if (ModelState.IsValid)
                {
                try
                    {
                    _context.Update(cash);
                    await _context.SaveChangesAsync();
                    }
                catch (DbUpdateConcurrencyException)
                    {
                    if (!CashExists(cash.Id))
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
            return View(cash);
            }

        public async Task<IActionResult> Delete(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var cash = await _context.Cashes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cash == null)
                {
                return NotFound();
                }

            return View(cash);
            }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
            var cash = await _context.Cashes.FindAsync(id);
            _context.Cashes.Remove(cash);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }

        private bool CashExists(int id)
            {
            return _context.Cashes.Any(e => e.Id == id);
            }
        }
    }
