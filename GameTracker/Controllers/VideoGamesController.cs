using System;
using System.Web.Mvc;
using System.Web.Services.Description;
using GameTracker.Models.VideoGameModel;
using GameTracker.Services;
using Microsoft.AspNet.Identity;

namespace GameTracker.Controllers
{
        [Authorize]
    public class VideoGamesController : Controller
    {
        public ActionResult Index()
        {
            var service = CreateVideoGameService();
            var model = service.GetVideoGames();
            return View(model);
        }
        public ActionResult VideoGameCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VideoGameCreate(VideoGameAdd model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateVideoGameService();
            if (service.VideoGameAdd(model))
            {
                TempData["SaveResult"] = "Your Video Game was created successfully."; 
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Video Game could not be created.");
            return View(model);
        }
        public ActionResult VideoGameDetails(int id)
        {
            var svc = CreateVideoGameService();
            var model = svc.VideoGameDetails(id);
            var qService = new QuestServices();
            var iService = new InventoryServices();
            var bService = new BossServices();
            var aService = new AchievementServices();
            ViewBag.Quests = qService.GetQuests(id);
            ViewBag.Inventories = iService.GetItems(id);
            ViewBag.Bosses = bService.GetBosses(id);
            ViewBag.Achievements = aService.GetAchievements(id);
            return View(model);
        }
        public ActionResult VideoGameEdit(int id)
        {
            var service = CreateVideoGameService();
            var detail = service.VideoGameDetails(id);
            var model = new VideoGameEdit
                {
                    VideoGameID = detail.VideoGameID,
                    VideoGameName = detail.VideoGameName,
                    VideoGameGenre = detail.VideoGameGenre,
                    VideoGameNotes = detail.VideoGameNotes,
                    TimesBeat = detail.TimesBeat
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VideoGameEdit(int id, VideoGameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VideoGameID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateVideoGameService();

            if (service.UpdateVideoGame(model))
            {
                TempData["SaveResult"] = "Your Video Game was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Video Game could not be updated.");
            return View(model);
        }
        [ActionName("VideoGameDelete")]
        public ActionResult VideoGameDelete(int id)
        {
            var svc = CreateVideoGameService();
            var model = svc.VideoGameDetails(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("VideoGameDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVideoGame(int id)
        {
            var service = CreateVideoGameService();
            service.DeleteVideoGame(id);
            TempData["SaveResult"] = "Your Video Game was deleted";
            return RedirectToAction("Index");
        }
        private VideoGameServices CreateVideoGameService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VideoGameServices(userID);
            return service;
        }
    }
}