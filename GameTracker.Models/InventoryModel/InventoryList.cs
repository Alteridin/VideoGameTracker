using GameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.InventoryModel
{
    public class InventoryList
    {
        public int InventoryID { get; set; }
        [Display(Name = "Inventory Item:")]
        public string InventoryItem { get; set; }
        [Display(Name = "Item Quantity:")]
        public int ItemQuantity { get; set; }
        [Display(Name = "Item Description:")]
        public string ItemDescription { get; set; }
        [Display(Name = "Item Acquired:")]
        public bool ItemAcquired { get; set; }
        public virtual VideoGame VideoGame { get; set; }
        public int VideoGameID { get; set; }
    }
}
