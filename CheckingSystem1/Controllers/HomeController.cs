
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckingSystem1.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CheckingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly CheckingSystemDBContext _context;

        public HomeController(CheckingSystemDBContext context)
        {
            _context = context;
        }
        

        public IActionResult Index()
        {
            List<Incidents> incident;
            incident = _context.Incidents.ToList();
            int incnber = _context.Incidents.Count();
            int soft = 0;
            int hard = 0;
            int db = 0;
            int net = 0;
            foreach (var item in incident)
            {
                
                if(item.IdCat.ToString()=="1")
                {
                    soft = soft + 1;
                }
                else if (item.IdCat.ToString() == "2")
                {
                    hard = hard + 1;
                }
                else if (item.IdCat.ToString() == "4")
                {
                    db = db + 1;
                }
                else 
                {
                    net = net + 1;
                }
                
            }
            double persoft= (double)(soft * 100) / incnber;
            double perhard = (double)(hard * 100) / incnber;
            double perdb = (double)(db * 100) / incnber;
            double pernet = (double)(net * 100) / incnber;
            ViewBag.persoft= (Math.Round(persoft,0));
            ViewBag.perhard = (Math.Round(perhard,0));
            ViewBag.perdb = (Math.Round(perdb,0));
            ViewBag.pernet = (Math.Round(pernet,0));
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
