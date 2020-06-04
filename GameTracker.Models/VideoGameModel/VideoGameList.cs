using GameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.VideoGameModel
{
    public class VideoGameList
    {
        public int VideoGameID { get; set; }
        [Display(Name = "Name of Video Game:")]
        public string VideoGameName { get; set; }
        [Display(Name = "Video Game Genre:")]
        public VGGenre VideoGameGenre { get; set; }
        [Display(Name = "Video Game Notes:")]
        public string VideoGameNotes { get; set; }
        [Display(Name = "Times Beaten:")]
        public int TimesBeat { get; set; }
    }
}
