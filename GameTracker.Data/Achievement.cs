using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Data
{
    public class Achievement
    {
        [Key]
        public int AchievementID { get; set; }
        [Required]
        public string AchievementName { get; set; }
        public string AchievementNotes { get; set; }
        [Required]
        public bool AchievementCompleted { get; set; }
        [Required]
        public int VideoGameID { get; set; }
        [ForeignKey(nameof(VideoGameID))]
        public virtual VideoGame VideoGame { get; set; }
    }
}
