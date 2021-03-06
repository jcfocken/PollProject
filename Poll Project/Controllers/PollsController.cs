﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Poll_Project.Models;

namespace Poll_Project.Controllers
{
    public class PollsController : Controller
    {
        private IApplicationDbContext db;
        
        public PollsController()
        {
            db = new ApplicationDbContext();
        }

        public PollsController(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: Polls
        
        public ActionResult Index()
        {
            return View(db.Polls.ToList());
        }

        // GET: Polls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }

            DetailsPollViewModel ViewModel = new DetailsPollViewModel(poll);
            return View(ViewModel);
        }

        // GET: Polls/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Polls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.Polls.Add(poll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poll);
        }

        // GET: Polls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: Polls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.SetModified(poll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poll);
        }

        // GET: Polls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: Polls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poll poll = db.Polls.Find(id);
            db.Polls.Remove(poll);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Polls/Results/5
        public ActionResult Results(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Poll poll = db.Polls.Find(id);

            if (poll == null)
            {
                return HttpNotFound();
            }

            PollResultsViewModel ViewModel = new PollResultsViewModel(poll);
            return View(ViewModel);
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
