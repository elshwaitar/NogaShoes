﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NogaShoesPOS.Models;
using System.Linq;
using System.Threading.Tasks;

namespace POSSystem.Controllers
    {
    public class ProductController : Controller
        {
        private readonly POSDbContext _context;

        public ProductController(POSDbContext context)
            {
            _context = context;
            }

        public async Task<IActionResult> Index()
            {
            return View(await _context.Products.ToListAsync());
            }

        public IActionResult Create()
            {
            return View();
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Stock")] Product product)
            {
            if (ModelState.IsValid)
                {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            return View(product);
            }

        public async Task<IActionResult> Edit(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                {
                return NotFound();
                }
            return View(product);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stock")] Product product)
            {
            if (id != product.Id)
                {
                return NotFound();
                }

            if (ModelState.IsValid)
                {
                try
                    {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    }
                catch (DbUpdateConcurrencyException)
                    {
                    if (!ProductExists(product.Id))
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
            return View(product);
            }

        public async Task<IActionResult> Delete(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
                {
                return NotFound();
                }

            return View(product);
            }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }

        private bool ProductExists(int id)
            {
            return _context.Products.Any(e => e.Id == id);
            }
        }
    }
