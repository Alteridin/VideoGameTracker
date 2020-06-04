using GameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.BossModel
{
    public class BossAdd
    {
        [Required]
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(40, ErrorMessage = "Must be within 40 characters...")]
        [Display(Name = "Name of Boss:")]
        public string BossName { get; set; }
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(1000, ErrorMessage = "Must be within 1000 characters...")]
        [Display(Name = "Notes on Boss:")]
        public string BossNotes { get; set; }
        [Required]
        [Display(Name = "Boss has been conquered:")]
        public bool BossBeaten { get; set; }
        [Required]
        public int VideoGameID { get; set; }
        public VideoGame VideoGame { get; set; }
    }
}
