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


        public ActionResult DeleteGroup(int id)
        {
            var votingGroup = db.VoutingGroups.Find(id);

            if (votingGroup != null)
            {
                db.VoutingGroups.Remove(votingGroup);
                db.SaveChanges();
            }

            return RedirectToAction(string.Format("Details/{0}", votingGroup.VoutingId));
        }

        public ActionResult DeleteCandidate(int id)
        {
            var candidate = db.Candidates.Find(id);

            if (candidate != null)
            {
                db.Candidates.Remove(candidate);
                db.SaveChanges();
            }

            return RedirectToAction(string.Format("Details/{0}", candidate.VoutingId));
        }

        public ActionResult AddCandidate(int id)
        {
            var view = new AddCandidateView
            {
                VoutingId = id,
            };

            ViewBag.UserId = new SelectList(db.Users
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName), 
                "UserId", "FullName");

            return View(view);
        }

        [HttpPost]
        public ActionResult AddCandidate(AddCandidateView view)
        {
            if (ModelState.IsValid)
            {
                var Candidate = db.Candidates
                    .Where(c => c.VoutingId == view.VoutingId &&
                                c.UserId == view.UserId)
                    .FirstOrDefault();

                if (Candidate != null)
                {
                    ModelState.AddModelError(string.Empty, 
                        "The Candidate already belongs to vouting.");
                    ViewBag.UserId = new SelectList(db.Users
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName),
                "UserId", "FullName");
                    return View(view);
                }

                Candidate = new Candidate
                {
                    UserId = view.UserId,
                    VoutingId = view.VoutingId,
                };

                db.Candidates.Add(Candidate);
                db.SaveChanges();
                return RedirectToAction(string.Format("Details/{0}", view.VoutingId));
            }

            ViewBag.UserId = new SelectList(db.Users
               .OrderBy(u => u.FirstName)
               .ThenBy(u => u.LastName),
               "UserId", "FullName");
            return View(view);
        }

        public ActionResult AddGroup(int id)
        {
            ViewBag.GroupId = new SelectList(db.Groups.OrderBy
                (g => g.Description), "GroupId", "Description");

            var view = new AddGroupView
            {
               VoutingId = id,
            };
            return View(view);
        }

        [HttpPost]
        public ActionResult AddGroup(AddGroupView view)
        {
            if (ModelState.IsValid)
            {
                var voutingGroup = db.VoutingGroups
                    .Where(vg => vg.VoutingId == view.VoutingId &&
                                 vg.GroupId == view.GroupId)
                    .FirstOrDefault();

                if (voutingGroup != null)
                {
                    ModelState.AddModelError(string.Empty, "The Group already belongs to vouting.");
                    ViewBag.Error = "The Group already belongs to vouting";
                    ViewBag.GroupId = new SelectList(db.Groups.OrderBy
                        (g => g.Description), "GroupId", "Description");
                    return View(view);
                }

                voutingGroup = new VoutingGroup
                {
                    GroupId = view.GroupId,
                    VoutingId = view.VoutingId,
                };

                db.VoutingGroups.Add(voutingGroup);
                db.SaveChanges();
                return RedirectToAction(string.Format("Details/{0}", view.VoutingId));
            }

            ViewBag.GroupId = new SelectList(db.Groups.OrderBy
                (g => g.Description), "GroupId", "Description");
            return View(view);
        }

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

            var view = new DetailsVotingView
            {
                Candidates     =        vouting.Candidates.ToList(),
                CandidateWinId =        vouting.CandidateWinId,
                DateTimeStart  =        vouting.DateTimeStart,
                DateTimeEnd    =        vouting.DateTimeEnd,
                Description    =        vouting.Description,
                IsEnableBlankVote=      vouting.IsEnableBlankVote,
                IsForAllUser   =        vouting.IsForAllUser,
                QuantityBlankVotes=     vouting.QuantityBlankVotes,
                QuantityVotes  =        vouting.QuantityVotes,
                Remarks        =        vouting.Remarks,
                StateId        =        vouting.StateId,
                VoutingGroups  =        vouting.VoutingGroups.ToList(),
                VoutingId      =        vouting.VoutingId  
            };
            return View(view);
        }

        // GET: Voutings/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.States, "StateId", "Description");
            var view = new VoutingView
            {
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now
            };
            return View(view);
        }

        // POST: Voutings/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoutingView view)
        {
            if (ModelState.IsValid)
            {
                var vouting = new Vouting
                {
                    DateTimeEnd = view.DateEnd.AddHours
                    (view.TimeEnd.Hour).AddMinutes
                    (view.TimeEnd.Minute),

                    DateTimeStart = view.DateStart.AddHours
                    (view.TimeStart.Hour).AddMinutes
                    (view.TimeStart.Minute),
                    Description = view.Description,
                    IsEnableBlankVote = view.IsEnableBlankVote,
                    IsForAllUser = view.IsForAllUser,
                    Remarks = view.Remarks,
                    StateId = view.StateId,                    
                };

                db.Voutings.Add(vouting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "StateId", "Description", view.StateId);
            return View(view);
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

            var view = new VoutingView
            {
                DateEnd = vouting.DateTimeEnd,
                DateStart = vouting.DateTimeStart,
                Description = vouting.Description,
                IsEnableBlankVote = vouting.IsEnableBlankVote,
                IsForAllUser = vouting.IsForAllUser,
                Remarks = vouting.Remarks,
                StateId = vouting.StateId,
                TimeEnd = vouting.DateTimeEnd,
                TimeStart = vouting.DateTimeStart,
                VoutingId = vouting.VoutingId,
            };

            ViewBag.StateId = new SelectList(db.States, "StateId", "Description", vouting.StateId);
            return View(view);
        }

        // POST: Voutings/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoutingView view)
        {
            if (ModelState.IsValid)
            {
                var vouting = new Vouting
                {
                    DateTimeEnd = view.DateEnd.AddHours
                    (view.TimeEnd.Hour).AddMinutes
                    (view.TimeEnd.Minute),

                    DateTimeStart = view.DateStart.AddHours
                    (view.TimeStart.Hour).AddMinutes
                    (view.TimeStart.Minute),
                    Description = view.Description,
                    IsEnableBlankVote = view.IsEnableBlankVote,
                    IsForAllUser = view.IsForAllUser,
                    Remarks = view.Remarks,
                    StateId = view.StateId,
                    VoutingId = view.VoutingId,
                };

                db.Entry(vouting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "Description", view.StateId);
            return View(view);
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
