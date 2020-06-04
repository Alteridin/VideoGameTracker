using GameTracker.Data;
using GameTracker.Models.InventoryModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameTracker.Services
{
    public class InventoryServices
    {
        public bool InventoryAdd(InventoryAdd model)
        {
            var entity = new Inventory()
            {
                VideoGameID = model.VideoGameID,
                InventoryItem = model.InventoryItem,
                ItemQuantity = model.ItemQuantity,
                ItemDescription = model.ItemDescription,
                ItemAcquired = model.ItemAcquired
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Inventories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InventoryList> GetItems(int videoGameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Inventories.Where(e => e.VideoGameID == videoGameID).Select(e => new InventoryList
                {
                    InventoryID = e.InventoryID,
                    InventoryItem = e.InventoryItem,
                    ItemQuantity = e.ItemQuantity,
                    ItemDescription = e.ItemDescription,
                    ItemAcquired = e.ItemAcquired,
                    VideoGameID = e.VideoGameID
                });
                return query.ToArray();
            }
        }
        public InventoryDetail InventoryDetails(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Inventories.Single(e => e.InventoryID == id);
                return new InventoryDetail
                {
                    InventoryID = entity.InventoryID,
                    InventoryItem = entity.InventoryItem,
                    ItemQuantity = entity.ItemQuantity,
                    ItemDescription = entity.ItemDescription,
                    ItemAcquired = entity.ItemAcquired,
                    VideoGameID = entity.VideoGameID
                };
            }
        }
        public bool UpdateInventory(InventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Inventories.Single(e => e.InventoryID == model.InventoryID && e.VideoGameID == model.VideoGameID);
                entity.InventoryItem = model.InventoryItem;
                entity.ItemQuantity = model.ItemQuantity;
                entity.ItemDescription = model.ItemDescription;
                entity.ItemAcquired = model.ItemAcquired;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteItem(int inventoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Inventories.Single(e => e.InventoryID == inventoryID);
                ctx.Inventories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
