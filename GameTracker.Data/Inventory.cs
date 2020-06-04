using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Data
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        [Required]
        public string InventoryItem { get; set; }
        [Required]
        public int ItemQuantity { get; set; }
        public string ItemDescription { get; set; }
        [Required]
        public bool ItemAcquired { get; set; }
        [Required]
        public int VideoGameID { get; set; }
        [ForeignKey(nameof(VideoGameID))]
        public virtual VideoGame VideoGame { get; set; }
    }
}
