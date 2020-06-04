using GameTracker.Models.QuestModel;
using GameTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GameTracker.Controllers
{
    [Authorize]
    public class QuestsController : Controller
    {
        public ActionResult Index()
        {
            var model = new QuestList[0];
            return View(model);
        }
        public ActionResult QuestCreate()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var db = new VideoGameServices(userID);
            ViewBag.VideoGameID = new SelectList(db.GetVideoGames().ToList(), "VideoGameID", "VideoGameName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuestCreate(QuestAdd model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateQuestService();
            if (service.QuestAdd(model))
            {
                TempData["SaveResult"] = "Your Quest was created successfully.";
                return RedirectToAction("Index", "VideoGames");
            }
            ModelState.AddModelError("", "Quest could not be created.");
            return View(model);
        }
        public ActionResult QuestDetails(int id)
        {
            var svc = CreateQuestService();
            var model = svc.QuestDetails(id);
            return View(model);
        }
        public ActionResult QuestEdit(int id)
        {
            var service = CreateQuestService();
            var detail = service.QuestDetails(id);
            var model = new QuestEdit
            {
                QuestID = detail.QuestID,
                QuestName = detail.QuestName,
                QuestNotes = detail.QuestNotes,
                MainQuest = detail.MainQuest,
                QuestComplete = detail.QuestComplete,
                VideoGameID = detail.VideoGameID
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuestEdit(int id, QuestEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.QuestID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateQuestService();

            if (service.UpdateQuest(model))
            {
                TempData["SaveResult"] = "Your Quest was updated.";
                return RedirectToAction("Index", "VideoGames");
            }

            ModelState.AddModelError("", "Your Quest could not be updated.");
            return View(model);
        }
        [ActionName("QuestDelete")]
        public ActionResult QuestDelete(int id)
        {
            var svc = CreateQuestService();
            var model = svc.QuestDetails(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("QuestDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteQuest(int id)
        {
            var service = CreateQuestService();
            service.DeleteQuest(id);
            TempData["SaveResult"] = "Your Quest was deleted";
            return RedirectToAction("Index", "VideoGames");
        }
        private QuestServices CreateQuestService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new QuestServices();
            return service;
        }
    }
}