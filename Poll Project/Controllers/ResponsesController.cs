using System;
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
    public class ResponsesController : Controller
    {
        private IApplicationDbContext db;

        public ResponsesController()
        {
            db = new ApplicationDbContext();
        }

        public ResponsesController(IApplicationDbContext dbContext)
        {   
            db = dbContext;
        }

        // GET: Responses
        public ActionResult Index()
        {
            return View(db.Responses.ToList());
        }

        // GET: Responses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
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

            CreateResponseViewModel viewmodel = new CreateResponseViewModel(poll);
            return View(viewmodel);
        }

        // POST: Responses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateResponseViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Poll poll = db.Polls.Find(viewmodel.Poll.ID);
                Response PollResponse = new Response
                {
                    Poll = poll,
                    Selections = new List<Selection>()
                };
                foreach (int selectionAnswerID in viewmodel.Selections)
                {
                    Answer answer = db.Answers.Find(selectionAnswerID);
                    PollResponse.Selections.Add(new Selection { Answer = answer });
                }
                db.Responses.Add(PollResponse);
                db.SaveChanges();
                return RedirectToAction("Index", "Polls");
            }

            return View(viewmodel);
        }

        // GET: Responses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // POST: Responses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text")] Response response)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(response).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(response);
        }

        // GET: Responses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Response response = db.Responses.Find(id);
            db.Responses.Remove(response);
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
