using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Data
{
    public class Boss
    {
        [Key]
        public int BossID { get; set; }
        [Required]
        public string BossName { get; set; }
        public string BossNotes { get; set; }
        [Required]
        public bool BossBeaten { get; set; }
        [Required]
        public int VideoGameID { get; set; }
        [ForeignKey(nameof(VideoGameID))]
        public virtual VideoGame VideoGame { get; set; }
    }
}
