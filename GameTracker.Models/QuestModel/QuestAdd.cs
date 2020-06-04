using GameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.QuestModel
{
    public class QuestAdd
    {
        [Required]
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(40, ErrorMessage = "Must be within 40 characters...")]
        [Display(Name = "Name of Quest:")]
        public string QuestName { get; set; }
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(1000, ErrorMessage = "Must be within 1000 characters...")]
        [Display(Name = "Quest Notes:")]
        public string QuestNotes { get; set; }
        [Required]
        [Display(Name = "Main Quest:")]
        public bool MainQuest { get; set; }
        [Required]
        [Display(Name = "Quest Completed:")]
        public bool QuestComplete { get; set; }
        [Required]
        public int VideoGameID { get; set; }
        public virtual VideoGame VideoGame { get; set; }
    }
}
