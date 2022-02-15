using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckingSystem1.Models;

namespace CheckingSystem.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly CheckingSystemDBContext _context;

        public SubCategoriesController(CheckingSystemDBContext context)
        {
            _context = context;
        }

        // GET: SubCategories
        public async Task<IActionResult> Index()
        {
            var checkingSystemDBContext = _context.SubCategories.Include(s => s.Category);
            return View(await checkingSystemDBContext.ToListAsync());
        }

        // GET: SubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategories = await _context.SubCategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.IdSubCat == id);
            if (subCategories == null)
            {
                return NotFound();
            }

            return View(subCategories);
        }

        // GET: SubCategories/Create
        public IActionResult Create()
        {
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubCat,Name,IdCat")] SubCategories subCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", subCategories.IdCat);
            return View(subCategories);
        }

        // GET: SubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategories = await _context.SubCategories.FindAsync(id);
            if (subCategories == null)
            {
                return NotFound();
            }
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", subCategories.IdCat);
            return View(subCategories);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubCat,Name,IdCat")] SubCategories subCategories)
        {
            if (id != subCategories.IdSubCat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoriesExists(subCategories.IdSubCat))
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
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", subCategories.IdCat);
            return View(subCategories);
        }

        // GET: SubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategories = await _context.SubCategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.IdSubCat == id);
            if (subCategories == null)
            {
                return NotFound();
            }

            return View(subCategories);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategories = await _context.SubCategories.FindAsync(id);
            _context.SubCategories.Remove(subCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoriesExists(int id)
        {
            return _context.SubCategories.Any(e => e.IdSubCat == id);
        }
    }
}
