using GameTracker.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.AchievementModel
{
    public class AchievementAdd
    {
        [Required]
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(40, ErrorMessage = "Must be within 40 characters...")]
        [Display(Name = "Name of Achievement:")]
        public string AchievementName { get; set; }
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(1000, ErrorMessage = "Must be within 1000 characters...")]
        [Display(Name = "Achievement Notes:")]
        public string AchievementNotes { get; set; }
        [Required]
        [Display(Name = "Achievement Obtained:")]
        public bool AchievementCompleted { get; set; }
        [Required]
        public int VideoGameID { get; set; }
        public virtual VideoGame VideoGame { get; set; }
    }
}
