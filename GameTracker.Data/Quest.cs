using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Data
{
    public class Quest
    {
        [Key]
        public int QuestID { get; set; }
        [Required]
        public string QuestName { get; set; }
        public string QuestNotes { get; set; }
        [Required]
        public bool MainQuest { get; set; }
        [Required]
        public bool QuestComplete { get; set; }
        [Required]
        public int VideoGameID { get; set; }
        [ForeignKey(nameof(VideoGameID))]
        public virtual VideoGame VideoGame { get; set; }
    }
}
