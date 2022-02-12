using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckingSystem.Models;
using System.Data;
using System.Data.SqlClient;


namespace CheckingSystem.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly CheckingSystemDBContext _context;
        database_access_layer.db dbop = new database_access_layer.db();
           

        public IncidentsController(CheckingSystemDBContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            var checkingSystemDBContext = _context.Incidents.Include(i => i.Categories).Include(i => i.User).Include(i => i.admin);
            return View(await checkingSystemDBContext.ToListAsync());
        }

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidents = await _context.Incidents
                .Include(i => i.Categories)
                .Include(i => i.User)
                .Include(i => i.admin)
                .FirstOrDefaultAsync(m => m.IdInc == id);
            if (incidents == null)
            {
                return NotFound();
            }

            return View(incidents);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {
            
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name");
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "FirstName");
            ViewData["Idadmin"] = new SelectList(_context.admin, "IdAdmin", "FirstName");
            ViewData["IdAgent"] = new SelectList(_context.SupportAgents, "IdAgent", "FirstName");
            DataSet ds = dbop.GetCategories();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["IdCat"].ToString()});
            }
            ViewBag.CategoriesList = list;

            return View();
        }
        public JsonResult GetSubCategoriesList(int catid)
        {
            DataSet ds = dbop.GetSubCategories(catid);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["IdSubCat"].ToString()});
            }
            return Json(list);
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInc,Caller,Category,Subcategory,BusinessService,Description,ContactType,state,priority,AssignementGroup,AssignementTo,Updatedate,UbdatedBy,IdCat,IdUser,Idadmin,IdAgent")] Incidents incidents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", incidents.IdCat);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "FirstName", incidents.IdUser);
            ViewData["Idadmin"] = new SelectList(_context.admin, "IdAdmin", "FirstName", incidents.Idadmin);
            ViewData["IdAgent"] = new SelectList(_context.SupportAgents, "IdAgent", "FirstName", incidents.IdAgent);


            return View(incidents);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidents = await _context.Incidents.FindAsync(id);
            if (incidents == null)
            {
                return NotFound();
            }
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", incidents.IdCat);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "FirstName", incidents.IdUser);
            ViewData["Idadmin"] = new SelectList(_context.admin, "IdAdmin", "FirstName", incidents.Idadmin);
            ViewData["IdAgent"] = new SelectList(_context.SupportAgents, "IdAgent", "FirstName", incidents.IdAgent);

            return View(incidents);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInc,Caller,Category,Subcategory,BusinessService,Description,ContactType,state,priority,AssignementGroup,AssignementTo,Updatedate,UbdatedBy,IdCat,IdUser,Idadmin,IdAgent")] Incidents incidents)
        {
            if (id != incidents.IdInc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentsExists(incidents.IdInc))
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
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", incidents.IdCat);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "FirstName", incidents.IdUser);
            ViewData["Idadmin"] = new SelectList(_context.admin, "IdAdmin", "FirstName", incidents.Idadmin);
            ViewData["IdAgent"] = new SelectList(_context.SupportAgents, "IdAgent", "FirstName", incidents.IdAgent);

            return View(incidents);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidents = await _context.Incidents
                .Include(i => i.Categories)
                .Include(i => i.User)
                .Include(i => i.admin)
                .FirstOrDefaultAsync(m => m.IdInc == id);
            if (incidents == null)
            {
                return NotFound();
            }

            return View(incidents);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidents = await _context.Incidents.FindAsync(id);
            _context.Incidents.Remove(incidents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentsExists(int id)
        {
            return _context.Incidents.Any(e => e.IdInc == id);
        }
    }
}
