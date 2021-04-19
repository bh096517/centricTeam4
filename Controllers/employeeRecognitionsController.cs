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
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace centricTeam4.Controllers
{
    public class employeeRecognitionsController : Controller
    {
        private MIS4200Team4Context db = new MIS4200Team4Context();

        // GET: employeeRecognitions
        public ActionResult Index()
        {
            //var profile = db.profile;
            //var sortedProfile = profile.OrderBy(r => r.lastName).ThenBy(r => r.firstName);
            //return View(sortedProfile.ToList());
            var recognition = db.EmployeeRecognitions.Include(r => r.personGettingRecognition);
            return View(recognition.ToList());
        }

        // GET: employeeRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            var recognition = db.EmployeeRecognitions.Include(r => r.personGettingRecognition);
            var ProfileGive = db.profile.Include(g => g.personGivingRecognition);
            var ProfileDate = db.profile.Include(d => d.recognitionDate);
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
            var profile = db.profile.OrderBy(c => c.lastName).ThenBy(c => c.firstName);
            //var sortedProfile = profile.OrderBy(r => r.lastName).ThenBy(r => r.firstName);
            ViewBag.recognizor = new SelectList(profile, "ProfileID", "fullName");
            var Profile = db.profile.OrderBy(c => c.lastName).ThenBy(c => c.firstName);
            //var sortedProfiles = profile.OrderBy(r => r.lastName).ThenBy(r => r.firstName);
            ViewBag.recognized = new SelectList(profile, "ProfileID", "fullName");
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
                employeeRecognition.recognizationDate = DateTime.Now;
                Guid employeeID;
                Guid.TryParse(User.Identity.GetUserId(), out employeeID);
                employeeRecognition.recognizor = employeeID;
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
            //   var employeeRecognition = db.EmployeeRecognitions.Where(e=>e.ID==id).Include(r => r.personGivingRecognition).Include(r => r.personGettingRecognition);
            //  var employeeRecognition = db.EmployeeRecognitions.Where(e => e.ID == id);
            var employeeRecognition = db.EmployeeRecognitions.Find(id);

            if (employeeRecognition == null)
            {
                return HttpNotFound();
            }
            var profile = db.profile.OrderBy(c => c.lastName).ThenBy(c => c.firstName);
            var IDCheck = employeeRecognition.recognizor;
            Guid employeeID;
            Guid.TryParse(User.Identity.GetUserId(), out employeeID);
            if (IDCheck == employeeID)
            {


                ViewBag.recognizor = new SelectList(profile, "ProfileID", "fullName", employeeRecognition.recognizor);
                ViewBag.recognized = new SelectList(profile, "ProfileID", "fullName", employeeRecognition.recognized);

                return View(employeeRecognition);
            }
            else
            {
                return View("NotAllowed");
            }
            //return View();
            //var editRecognition = employeeRecognition.Include(r => r.personGivingRecognition).Include(r => r.personGettingRecognition);
            //return View(editRecognition.ToList());

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
            var profile = db.profile.OrderBy(c => c.lastName).ThenBy(c => c.firstName);
            ViewBag.recognizor = new SelectList(profile, "ProfileID", "fullName", employeeRecognition.recognizor);
            ViewBag.recognized = new SelectList(profile, "ProfileID", "fullName", employeeRecognition.recognized);
            return View(employeeRecognition);
            //var editRecognition = db.EmployeeRecognitions.Include(r => r.personGivingRecognition).Include(r => r.personGettingRecognition);
            //return View(editRecognition.ToList());
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
            //var profile = db.profile.OrderBy(c => c.lastName).ThenBy(c => c.firstName);
            var IDCheck = employeeRecognition.recognizor;
            Guid employeeID;
            Guid.TryParse(User.Identity.GetUserId(), out employeeID);
            if (IDCheck == employeeID)
            {


                //ViewBag.recognizor = new SelectList(profile, "ProfileID", "fullName", employeeRecognition.recognizor);
                //ViewBag.recognized = new SelectList(profile, "ProfileID", "fullName", employeeRecognition.recognized);

                return View(employeeRecognition);
            }
            else
            {
                return View("DeleteNotAllowed");
            }
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
