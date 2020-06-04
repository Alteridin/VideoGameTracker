using GameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.QuestModel
{
    public class QuestDetail
    {
        public int QuestID { get; set; }
        [Display(Name = "Name of Quest:")]
        public string QuestName { get; set; }
        [Display(Name = "Quest Notes:")]
        public string QuestNotes { get; set; }
        [Display(Name = "Main or Side Quest:")]
        public bool MainQuest { get; set; }
        [Display(Name = "Quest Completed:")]
        public bool QuestComplete { get; set; }
        public int VideoGameID { get; set; }
        public virtual VideoGame VideoGame { get; set; }
    }
}
