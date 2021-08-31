using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitap1.Models;
namespace baitap1.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        Class1 GPT = new Class1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string soA, string soB)
        {
            double so1 = Convert.ToDouble(soA);
            double so2 = Convert.ToDouble(soB);
            double kq = GPT.GiaiPT(so1, so2);
            ViewBag.KetQua = kq;
            return View();
        }
    }
}