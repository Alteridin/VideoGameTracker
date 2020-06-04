using GameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.InventoryModel
{
    public class InventoryEdit
    {
        [Required]
        public int InventoryID { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(40, ErrorMessage = "Must be within 40 characters...")]
        [Display(Name = "Inventory Item:")]
        public string InventoryItem { get; set; }
        [Required]
        [Display(Name = "Item Quantity:")]
        public int ItemQuantity { get; set; }
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(1000, ErrorMessage = "Must be within 1000 characters...")]
        [Display(Name = "Item Description:")]
        public string ItemDescription { get; set; }
        [Required]
        [Display(Name = "Item Acquired:")]
        public bool ItemAcquired { get; set; }
        [Required]
        public int VideoGameID { get; set; }
        public virtual VideoGame VideoGame { get; set; }
    }
}
