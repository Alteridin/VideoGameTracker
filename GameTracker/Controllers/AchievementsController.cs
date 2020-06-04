using GameTracker.Models.AchievementModel;
using GameTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GameTracker.Controllers
{
    public class AchievementsController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new AchievementList[0];
            return View(model);
        }
        public ActionResult AchievementCreate()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var db = new VideoGameServices(userID);
            ViewBag.VideoGameID = new SelectList(db.GetVideoGames().ToList(), "VideoGameID", "VideoGameName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AchievementCreate(AchievementAdd model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateAchievementService();
            if (service.AchievementAdd(model))
            {
                TempData["SaveResult"] = "Your Achievement was created successfully.";
                return RedirectToAction("Index", "VideoGames");
            }
            ModelState.AddModelError("", "Achievement could not be created.");
            return View(model);
        }
        public ActionResult AchievementDetails(int id)
        {
            var svc = CreateAchievementService();
            var model = svc.AchievementDetails(id);
            return View(model);
        }
        public ActionResult AchievementEdit(int id)
        {
            var service = CreateAchievementService();
            var detail = service.AchievementDetails(id);
            var model = new AchievementEdit
            {
                AchievementID = detail.AchievementID,
                AchievementName = detail.AchievementName,
                AchievementNotes = detail.AchievementNotes,
                AchievementCompleted = detail.AchievementCompleted,
                VideoGameID = detail.VideoGameID
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AchievementEdit(int id, AchievementEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AchievementID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAchievementService();

            if (service.UpdateAchievement(model))
            {
                TempData["SaveResult"] = "Your Achievement was updated.";
                return RedirectToAction("Index", "VideoGames");
            }

            ModelState.AddModelError("", "Your Achievement could not be updated.");
            return View(model);
        }
        [ActionName("AchievementDelete")]
        public ActionResult AchievementDelete(int id)
        {
            var svc = CreateAchievementService();
            var model = svc.AchievementDetails(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("AchievementDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAchievement(int id)
        {
            var service = CreateAchievementService();
            service.DeleteAchievement(id);
            TempData["SaveResult"] = "Your Achievement was deleted";
            return RedirectToAction("Index", "VideoGames");
        }
        private AchievementServices CreateAchievementService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new AchievementServices();
            return service;
        }
    }
}