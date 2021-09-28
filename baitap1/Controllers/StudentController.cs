using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baitap1.Models;
using baitap1.Models.Process;

namespace baitap1.Controllers
{
    public class StudentController : Controller
    {
        private LTQLDbContext db = new LTQLDbContext();
        private StringProcess strPro = new StringProcess();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            var model = db.Students.ToList();
            //kiểm tra đối tượng đã có dữ liệu 
            //nếu chưa có trả 1 mã mặc định ban đầu 
            if (model.Count == 0)
            {
                ViewBag.StudentID = "STD001";
            }
            //nếu có rồi tao sinh mã tự động 
            else
            {
                //lấy ra mã sv mới nhất 
                var idStudent = model.OrderByDescending(m => m.StudentID).FirstOrDefault().StudentID;
                var newKey = strPro.AutoGenerateKey(idStudent);
                ViewBag.StudentID = newKey;

            }
            //trả về mã từ dòng view
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Studentname,Address")] Student student)
        {
            // đưa câu lệnh có thể gây ra lỗi vào try 
            try
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            // xử lý các lỗi có thể phát sinh 
            catch (Exception)
            {
                ModelState.AddModelError("", "khoa chinh bi trung vui long nhap lai");
                return View(student);
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Studentname,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
