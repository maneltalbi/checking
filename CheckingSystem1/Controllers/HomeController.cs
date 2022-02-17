using CheckingSystem1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
             List<Incidents> list = new List<Incidents>();
            list = _context.Incidents.ToList();
            List<int> repartition = new List<int>();
            var cat = list.Select(x => x.Category).Distinct();
            foreach (var item in cat)
            {
                repartition.Add(list.Count(x => x.Category ==item));
            }
            var rep = repartition;
            ViewBag.cat = cat;
            ViewBag.rep = repartition.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public JsonResult Dashboardcount()
        {
            try
            {
                string[] Dashboardcount = new string[2];
                SqlConnection con = new SqlConnection(@"Server=.;Database=CheckingSystem;Trusted_Connection=True;MultipleActiveResultSets=true");
                con.Open();
                SqlCommand cmd = new SqlCommand();
DataTable dt = new DataTable();
                SqlDataAdapter cmd1 = new SqlDataAdapter(cmd);
                cmd1.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    Dashboardcount[0] = "0";
                    Dashboardcount[1] = "0";
                    Dashboardcount[2] = "0";
                    Dashboardcount[3] = "0";
                }
                else
                {
                    Dashboardcount[0] = dt.Rows[0]["Hardware"].ToString();
                    Dashboardcount[1] = dt.Rows[0]["Software"].ToString();
                    Dashboardcount[2] = dt.Rows[0]["Network"].ToString();
                    Dashboardcount[3] = dt.Rows[0]["database"].ToString();

                }
                return Json(new { Dashboardcount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
