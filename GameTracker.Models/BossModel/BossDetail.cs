using GameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.BossModel
{
    public class BossDetail
    {
        public int BossID { get; set; }
        [Display(Name = "Name of Boss:")]
        public string BossName { get; set; }
        [Display(Name = "Notes on Boss:")]
        public string BossNotes { get; set; }
        [Display(Name = "Boss has been conquered:")]
        public bool BossBeaten { get; set; }
        public int VideoGameID { get; set; }
        public virtual VideoGame VideoGame { get; set; }
    }
}
