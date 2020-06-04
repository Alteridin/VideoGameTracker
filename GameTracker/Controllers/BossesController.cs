using GameTracker.Models.BossModel;
using GameTracker.Models.QuestModel;
using GameTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GameTracker.Controllers
{
    public class BossesController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new QuestList[0];
            return View(model);
        }
        public ActionResult BossCreate()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var db = new VideoGameServices(userID);
            ViewBag.VideoGameID = new SelectList(db.GetVideoGames().ToList(), "VideoGameID", "VideoGameName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BossCreate(BossAdd model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateBossService();
            if (service.BossAdd(model))
            {
                TempData["SaveResult"] = "Your Boss was created successfully.";
                return RedirectToAction("Index", "VideoGames");
            }
            ModelState.AddModelError("", "Boss could not be created.");
            return View(model);
        }
        public ActionResult BossDetails(int id)
        {
            var svc = CreateBossService();
            var model = svc.BossDetails(id);
            return View(model);
        }
        public ActionResult BossEdit(int id)
        {
            var service = CreateBossService();
            var detail = service.BossDetails(id);
            var model = new BossEdit
            {
                BossID = detail.BossID,
                BossName = detail.BossName,
                BossNotes = detail.BossNotes,
                BossBeaten = detail.BossBeaten,
                VideoGameID = detail.VideoGameID
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BossEdit(int id, BossEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BossID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBossService();

            if (service.UpdateBoss(model))
            {
                TempData["SaveResult"] = "Your Boss was updated.";
                return RedirectToAction("Index", "VideoGames");
            }

            ModelState.AddModelError("", "Your Boss could not be updated.");
            return View(model);
        }
        [ActionName("BossDelete")]
        public ActionResult BossDelete(int id)
        {
            var svc = CreateBossService();
            var model = svc.BossDetails(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("BossDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBoss(int id)
        {
            var service = CreateBossService();
            service.DeleteBoss(id);
            TempData["SaveResult"] = "Your Boss was deleted";
            return RedirectToAction("Index", "VideoGames");
        }
        private BossServices CreateBossService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BossServices();
            return service;
        }
    }
}