using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Democracy1.Models;

namespace Democracy1.Controllers
{
    [Authorize]
    public class VoutingsController : Controller
    {
        private DemocracyContext db = new DemocracyContext();

        // GET: Voutings
        public ActionResult Index()
        {
            var voutings = db.Voutings.Include(v => v.State);
            return View(voutings.ToList());
        }

        // GET: Voutings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vouting vouting = db.Voutings.Find(id);
            if (vouting == null)
            {
                return HttpNotFound();
            }
            return View(vouting);
        }

        // GET: Voutings/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.States, "StateId", "Description");
            return View();
        }

        // POST: Voutings/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoutingId,Description,StateId,Remarks,DateTimeStart,DateTimeEnd,IsForAllUser,IsEnableBlankVote,QuantityVotes,QuantityBlankVotes,CandidateWinId")] Vouting vouting)
        {
            if (ModelState.IsValid)
            {
                db.Voutings.Add(vouting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "StateId", "Description", vouting.StateId);
            return View(vouting);
        }

        // GET: Voutings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vouting vouting = db.Voutings.Find(id);
            if (vouting == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "Description", vouting.StateId);
            return View(vouting);
        }

        // POST: Voutings/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoutingId,Description,StateId,Remarks,DateTimeStart,DateTimeEnd,IsForAllUser,IsEnableBlankVote,QuantityVotes,QuantityBlankVotes,CandidateWinId")] Vouting vouting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vouting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "Description", vouting.StateId);
            return View(vouting);
        }

        // GET: Voutings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vouting vouting = db.Voutings.Find(id);
            if (vouting == null)
            {
                return HttpNotFound();
            }
            return View(vouting);
        }

        // POST: Voutings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vouting vouting = db.Voutings.Find(id);
            db.Voutings.Remove(vouting);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ViewBag.Error = "Can't delete the record, because it has related records";
                }
                else
                {
                    ViewBag.Error = ex.Message;
                }
                return View(vouting);
            }
            return RedirectToAction("index");
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
