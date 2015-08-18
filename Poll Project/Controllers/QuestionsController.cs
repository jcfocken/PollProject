using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Poll_Project.Models;
using System.Diagnostics;

namespace Poll_Project.Controllers
{
    public class QuestionsController : Controller
    {
        private IApplicationDbContext db;

        public QuestionsController()
        {
            db = new ApplicationDbContext();
        }

        public QuestionsController(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: Questions
        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Responses/Create
        public ActionResult Create(string pollId)
        {
            if (pollId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(Int32.Parse(pollId));
            if (poll == null)
            {
                return HttpNotFound();
            }

            CreateQuestionViewModel ViewModel = new CreateQuestionViewModel();
            ViewModel.Poll = poll;
            return View(ViewModel);
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateQuestionViewModel ViewModel)
        {
            var poll = db.Polls.Find(ViewModel.Poll.ID);
            ViewModel.Question.Poll = poll;
            ViewModel.Poll = poll;
            if (ModelState.IsValid)
            {
                db.Questions.Add(ViewModel.Question);
                db.SaveChanges();
                return RedirectToAction("Edit", "Polls", new { id = poll.ID });
            }

            return View(ViewModel);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text,PollID")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.SetModified(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
