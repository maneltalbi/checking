
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
            
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
