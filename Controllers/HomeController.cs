using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Net.Http;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var test = GetGWB();
            
            //var test1 = test.Result;
            return View();

            //return Ok(test.Result);
        }

        public async Task<bool> GetGWB()
        {
            HttpClient hc = new HttpClient();

            var t1 =  hc.GetAsync("http://geekswithblogs.net/default.aspx");
            var t2 =  hc.GetByteArrayAsync("http://geekswithblogs.net/default.aspx");
            var t3 =  hc.GetStringAsync("http://geekswithblogs.net/default.aspx");

            await Task.WhenAll(t1,t2,t3);

            //await hc.GetStringAsync("http://geekswithblogs.net/default.aspx");

            return true;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
