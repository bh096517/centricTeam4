using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using centricTeam4.DAL;
using centricTeam4.Models;

namespace centricTeam4.Controllers
{
    public class employeeRecognitionsController : Controller
    {
        private MIS4200Team4Context db = new MIS4200Team4Context();

        // GET: employeeRecognitions
        public ActionResult Index()
        {
            return View(db.EmployeeRecognitions.ToList());
        }

        // GET: employeeRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            return View(employeeRecognition);
        }

        // GET: employeeRecognitions/Create
       [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeRecognitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,award,recognizor,recognized,recognizationDate")] employeeRecognition employeeRecognition)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeRecognitions.Add(employeeRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeRecognition);
        }

        // GET: employeeRecognitions/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            return View(employeeRecognition);
        }

        // POST: employeeRecognitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       [Authorize]
        public ActionResult Edit([Bind(Include = "ID,award,recognizor,recognized,recognizationDate")] employeeRecognition employeeRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeRecognition);
        }

        // GET: employeeRecognitions/Delete/5
       [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            return View(employeeRecognition);
        }

        // POST: employeeRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeRecognition employeeRecognition = db.EmployeeRecognitions.Find(id);
            db.EmployeeRecognitions.Remove(employeeRecognition);
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
