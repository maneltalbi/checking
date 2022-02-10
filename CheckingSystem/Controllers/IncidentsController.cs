using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem.Controllers
{
    public class IncidentsController : Controller
    {
        // GET: IncidentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IncidentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IncidentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncidentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IncidentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IncidentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IncidentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IncidentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
