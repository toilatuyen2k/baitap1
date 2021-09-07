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
        //khai bao doi tuong can ke thua
        GiaiPhuongTrinh Gpt = new GiaiPhuongTrinh();

        // GET: Demo
        public ActionResult Timx()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Timx(string soA, string soB)
        {
            double so1 = Convert.ToDouble(soA);
            double so2 = Convert.ToDouble(soB);
            //ke thua phong thuc TimX
            double gt_x = Gpt.Timx(so1, so2);
            ViewBag.timgtx = gt_x;
            return View();
        }
    }
}