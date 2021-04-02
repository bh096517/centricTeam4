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

namespace centricTeam4.Controllers
{
    public class ProfilesController : Controller
    {
        private MIS4200Team4Context db = new MIS4200Team4Context();

        // GET: Profiles
        public ActionResult Index(int? page, string searchString)
        {
            //int pgSize = 10;
            int pageNumber = (page ?? 1);
            var Profile = from r in db.profile select r;
            // sort the records
            Profile = Profile.OrderBy(r => r.lastName).ThenBy(r => r.firstName);
            // check to see if a search was made a request it
            if(!string.IsNullOrEmpty(searchString))
            {
                Profile = Profile.Where(r => r.lastName.Contains(searchString) || (r.firstName.Contains(searchString)));
            }
            var profileList = Profile;
                //ToPagedList(pageNumber);
            return View(profileList);
            //var Profile = db.profile;
            //var sortedProfile = Profile.OrderBy(r => r.lastName).ThenBy(r => r.firstName);
            //return View(sortedProfile.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileID,lastName,firstName,office,position,hireDate,phoneNumber,email,/*photo*/")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                Guid employeeID;
                Guid.TryParse(User.Identity.GetUserId(), out employeeID);
                profile.ProfileID = employeeID;
                //profile.ProfileID = Guid.NewGuid();
                db.profile.Add(profile);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                    return View("DuplicateUser");
                }
                return RedirectToAction("Index");
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileID,lastName,firstName,office,position,hireDate,phoneNumber,email,/*photo*/")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Profile profile = db.profile.Find(id);
            db.profile.Remove(profile);
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
