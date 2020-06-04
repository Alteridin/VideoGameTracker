using GameTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.VideoGameModel
{
    public class VideoGameDetail
    {
        public int VideoGameID { get; set; }
        public Guid OwnerID { get; set; }
        [Display(Name = "Name of Video Game:")]
        public string VideoGameName { get; set; }
        [Display(Name = "Video Game Genre:")]
        public VGGenre VideoGameGenre { get; set; }
        [Display(Name = "Video Game Notes:")]
        public string VideoGameNotes { get; set; }
        [Display(Name = "Times Beaten:")]
        public int TimesBeat { get; set; }
        public List<Quest> Quests { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<Boss> Bosses { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
}
