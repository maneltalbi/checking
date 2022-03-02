using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckingSystem1.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CheckingSystem1.Controllers
{
    public class GoogleMapsController : Controller
    {
        private readonly CheckingSystemDBContext _context;

        public GoogleMapsController(CheckingSystemDBContext context)
        {
            _context = context;
        }

        // GET: GoogleMaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoogleMap.ToListAsync());
        }
        public ActionResult Location()
        {
            string markers = "[";
           
            using (SqlConnection con = new SqlConnection("Server=.;Database=CheckingSystem;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                SqlCommand cmd = new SqlCommand("spGetMap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    markers += "{";
                    markers += string.Format("'rat': '{0}',", sdr["Rating"]);
                    markers += string.Format("'adr': '{0}',", sdr["Address"]);
                    markers += string.Format("'lat': '{0}',", sdr["Lat"]);
                    markers += string.Format("'lng': '{0}'", sdr["Long"]);
                    markers += "},";
                }
            }
            markers += "];";
            ViewBag.Markers = markers;
            List<Incidents> list = new List<Incidents>();
            list = _context.Incidents.ToList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Location(GoogleMap location)
        {
            if (ModelState.IsValid)
            {
            using (SqlConnection con = new SqlConnection("Server=.;Database=CheckingSystem;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    SqlCommand cmd = new SqlCommand("spAddNewLocation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Rating", location.Rating);
                    cmd.Parameters.AddWithValue("@Address", location.Address);
                    cmd.Parameters.AddWithValue("@Lat", location.Lat);
                    cmd.Parameters.AddWithValue("@Long", location.Long);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {

            }
            return RedirectToAction("Location");
        }
        // GET: GoogleMaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var googleMap = await _context.GoogleMap
                .FirstOrDefaultAsync(m => m.IdMap == id);
            if (googleMap == null)
            {
                return NotFound();
            }

            return View(googleMap);
        }

        // GET: GoogleMaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoogleMaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMap,Rating,Address,Lat,Long")] GoogleMap googleMap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(googleMap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(googleMap);
        }

        // GET: GoogleMaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var googleMap = await _context.GoogleMap.FindAsync(id);
            if (googleMap == null)
            {
                return NotFound();
            }
            return View(googleMap);
        }

        // POST: GoogleMaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMap,Rating,Address,Lat,Long")] GoogleMap googleMap)
        {
            if (id != googleMap.IdMap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(googleMap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoogleMapExists(googleMap.IdMap))
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
            return View(googleMap);
        }

        // GET: GoogleMaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var googleMap = await _context.GoogleMap
                .FirstOrDefaultAsync(m => m.IdMap == id);
            if (googleMap == null)
            {
                return NotFound();
            }

            return View(googleMap);
        }

        // POST: GoogleMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var googleMap = await _context.GoogleMap.FindAsync(id);
            _context.GoogleMap.Remove(googleMap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoogleMapExists(int id)
        {
            return _context.GoogleMap.Any(e => e.IdMap == id);
        }
    }
}
