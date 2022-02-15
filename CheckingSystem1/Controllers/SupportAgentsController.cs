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
    public class SupportAgentsController : Controller
    {
        private readonly CheckingSystemDBContext _context;

        public SupportAgentsController(CheckingSystemDBContext context)
        {
            _context = context;
        }

        // GET: SupportAgents
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupportAgents.ToListAsync());
        }

        // GET: SupportAgents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportAgents = await _context.SupportAgents
                .FirstOrDefaultAsync(m => m.IdAgent == id);
            if (supportAgents == null)
            {
                return NotFound();
            }

            return View(supportAgents);
        }

        // GET: SupportAgents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportAgents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgent,LastName,FirstName,Email")] SupportAgents supportAgents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportAgents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportAgents);
        }

        // GET: SupportAgents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportAgents = await _context.SupportAgents.FindAsync(id);
            if (supportAgents == null)
            {
                return NotFound();
            }
            return View(supportAgents);
        }

        // POST: SupportAgents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAgent,LastName,FirstName,Email")] SupportAgents supportAgents)
        {
            if (id != supportAgents.IdAgent)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportAgents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportAgentsExists(supportAgents.IdAgent))
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
            return View(supportAgents);
        }

        // GET: SupportAgents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportAgents = await _context.SupportAgents
                .FirstOrDefaultAsync(m => m.IdAgent == id);
            if (supportAgents == null)
            {
                return NotFound();
            }

            return View(supportAgents);
        }

        // POST: SupportAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportAgents = await _context.SupportAgents.FindAsync(id);
            _context.SupportAgents.Remove(supportAgents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportAgentsExists(int id)
        {
            return _context.SupportAgents.Any(e => e.IdAgent == id);
        }
    }
}
