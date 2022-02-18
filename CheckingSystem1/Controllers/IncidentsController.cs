using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckingSystem1.Models;
using System.Data;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using System.Configuration;

namespace CheckingSystem1.Controllers
{
    public class IncidentsController : Controller
    {
        database_access_layer.db dbop = new database_access_layer.db();

        private readonly CheckingSystemDBContext _context;

        public IncidentsController(CheckingSystemDBContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public  IActionResult Index(string incsearch)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["CheckingSystem"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from [dbo].[Incidents] where Number like '%" + incsearch + "%'";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
           SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<Incidents> inc = new List<Incidents>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                inc.Add(new Incidents
                {
                    Number = Convert.ToString(dr["Number"]),
                    Subcategory = Convert.ToString(dr["Subcategory"]),
                    BusinessService = Convert.ToString(dr["BusinessService"]),
                    Description = Convert.ToString(dr["Description"]),
                    ContactType = Convert.ToString(dr["ContactType"]),
                    state = Convert.ToString(dr["state"]),
                    priority = Convert.ToString(dr["priority"]),
                    AssignementGroup = Convert.ToString(dr["AssignementGroup"]),
                    Updatedate = Convert.ToDateTime(dr["Updatedate"]),
                    UbdatedBy = Convert.ToString(dr["UbdatedBy"]),
                    IdCat = Convert.ToInt32(dr["IdCat"]),
                    IdUser = Convert.ToInt32(dr["IdUser"]),
                    Idadmin = Convert.ToInt32(dr["Idadmin"]),
                    IdAgent = Convert.ToInt32(dr["IdAgent"]),

                });
            }
            sqlconn.Close();
            ModelState.Clear();
       

            ViewBag.subcatlist = _context.SubCategories.ToList();
            return View(inc);

        }
       
        public async Task<IActionResult> Resolved()
        {
            ViewBag.subcatlist = _context.SubCategories.ToList();
            var checkingSystemDBContext = _context.Incidents.Include(i => i.AssignementTo).Include(i => i.Caller).Include(i => i.Category).Include(i => i.admin);
            return View(await checkingSystemDBContext.ToListAsync());
        }

        public async Task<IActionResult> AssignedToMe()
        {
            ViewBag.subcatlist = _context.SubCategories.ToList();
            var checkingSystemDBContext = _context.Incidents.Include(i => i.AssignementTo).Include(i => i.Caller).Include(i => i.Category).Include(i => i.admin);
            return View(await checkingSystemDBContext.ToListAsync());
            
        }

        // GET: Incidents/Create
        public IActionResult Create(int id=0)
        {
            ViewData["IdAgent"] = new SelectList(_context.SupportAgents, "IdAgent", "LastName");
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "LastName");
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name");
            ViewData["Idadmin"] = new SelectList(_context.admin, "IdAdmin", "LastName");
            Incidents inc = new Incidents();
            var lastincident = _context.Incidents.OrderByDescending(c => c.IdInc).FirstOrDefault();
            if (id != 0)
            {
                inc = _context.Incidents.Where(x => x.IdInc == id).FirstOrDefault<Incidents>();
            }
            else if (lastincident == null)
            {
                inc.Number = "INC0001";
            }
            else
            {
                inc.Number = "INC" + (Convert.ToInt32(lastincident.Number.Substring(6, lastincident.Number.Length - 6)) + 1).ToString("D4");
            }
            DataSet ds = dbop.GetCategories();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["IdCat"].ToString() });
            }
            ViewBag.CategoriesList = list;

            return View(inc);
        }
        public JsonResult GetSubCategoriesList(int catid)
        {
            DataSet ds = dbop.GetSubCategories(catid);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["IdSubCat"].ToString() });
            }
            return Json(list);
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInc,Number,Subcategory,BusinessService,Description,ContactType,state,priority,AssignementGroup,Updatedate,UbdatedBy,IdCat,IdUser,Idadmin,IdAgent")] Incidents incidents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAgent"] = new SelectList(_context.SupportAgents, "IdAgent", "LastName", incidents.IdAgent);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "LastName", incidents.IdUser);
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", incidents.IdCat);
            ViewData["Idadmin"] = new SelectList(_context.admin, "IdAdmin", "LastName", incidents.Idadmin);
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
            ViewData["IdAgent"] = new SelectList(_context.SupportAgents, "IdAgent", "LastName", incidents.IdAgent);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "LastName", incidents.IdUser);
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", incidents.IdCat);
            ViewData["Idadmin"] = new SelectList(_context.admin, "IdAdmin", "LastName", incidents.Idadmin);
            DataSet ds = dbop.GetCategories();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["IdCat"].ToString() });
            }
            ViewBag.CategoriesList = list;
            return View(incidents);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInc,Number,Subcategory,BusinessService,Description,ContactType,state,priority,AssignementGroup,Updatedate,UbdatedBy,IdCat,IdUser,Idadmin,IdAgent")] Incidents incidents)
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
            ViewData["IdAgent"] = new SelectList(_context.SupportAgents, "IdAgent", "LastName", incidents.IdAgent);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "LastNAme", incidents.IdUser);
            ViewData["IdCat"] = new SelectList(_context.Categories, "IdCat", "Name", incidents.IdCat);
            ViewData["Idadmin"] = new SelectList(_context.admin, "IdAdmin", "LastName", incidents.Idadmin);
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
                .Include(i => i.AssignementTo)
                .Include(i => i.Caller)
                .Include(i => i.Category)
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
