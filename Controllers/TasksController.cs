using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.OrderBy(t => t.DueDate).ToList();
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create() => View();

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (!ModelState.IsValid) return View(task);

            db.Tasks.Add(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var task = db.Tasks.Find(id);
            if (task == null) return HttpNotFound();

            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task)
        {
            if (!ModelState.IsValid) return View(task);

            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var task = db.Tasks.Find(id);
            if (task == null) return HttpNotFound();

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Tasks/ToggleComplete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToggleComplete(int id)
        {
            var task = db.Tasks.Find(id);
            if (task == null) return HttpNotFound();

            task.IsCompleted = !task.IsCompleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}