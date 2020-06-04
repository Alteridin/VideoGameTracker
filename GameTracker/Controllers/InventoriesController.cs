using GameTracker.Models.InventoryModel;
using GameTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GameTracker.Controllers
{
    public class InventoriesController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new InventoryList[0];
            return View(model);
        }
        public ActionResult InventoryCreate()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var db = new VideoGameServices(userID);
            ViewBag.VideoGameID = new SelectList(db.GetVideoGames().ToList(), "VideoGameID", "VideoGameName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InventoryCreate(InventoryAdd model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateInventoryService();
            if (service.InventoryAdd(model))
            {
                TempData["SaveResult"] = "Your Inventory was created successfully.";
                return RedirectToAction("Index", "VideoGames");
            }
            ModelState.AddModelError("", "Inventory could not be created.");
            return View(model);
        }
        public ActionResult InventoryDetails(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.InventoryDetails(id);
            return View(model);
        }
        public ActionResult InventoryEdit(int id)
        {
            var service = CreateInventoryService();
            var detail = service.InventoryDetails(id);
            var model = new InventoryEdit
            {
                InventoryID = detail.InventoryID,
                InventoryItem = detail.InventoryItem,
                ItemQuantity = detail.ItemQuantity,
                ItemDescription = detail.ItemDescription,
                ItemAcquired = detail.ItemAcquired,
                VideoGameID = detail.VideoGameID
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InventoryEdit(int id, InventoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InventoryID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateInventoryService();

            if (service.UpdateInventory(model))
            {
                TempData["SaveResult"] = "Your Invenetory was updated.";
                return RedirectToAction("Index", "VideoGames");
            }

            ModelState.AddModelError("", "Your Inventory could not be updated.");
            return View(model);
        }
        [ActionName("ItemDelete")]
        public ActionResult ItemDelete(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.InventoryDetails(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("ItemDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            var service = CreateInventoryService();
            service.DeleteItem(id);
            TempData["SaveResult"] = "Your Item was deleted";
            return RedirectToAction("Index", "VideoGames");
        }
        private InventoryServices CreateInventoryService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new InventoryServices();
            return service;
        }
    }
}