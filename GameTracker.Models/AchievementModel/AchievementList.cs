using GameTracker.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.AchievementModel
{
    public class AchievementList
    {
        public int AchievmentID { get; set; }
        [Display(Name = "Name of Achievement:")]
        public string AchievementName { get; set; }
        [Display(Name = "Achievement Notes:")]
        public string AchievementNotes { get; set; }
        [Display(Name = "Achievement Obtained:")]
        public bool AchievementCompleted { get; set; }
        public virtual VideoGame VideoGame { get; set; }
        public int VideoGameID { get; set; }
    }
}
