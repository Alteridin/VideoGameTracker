using GameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models.VideoGameModel
{
    public class VideoGameEdit
    {
        public int VideoGameID { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(40, ErrorMessage = "Must be within 40 characters...")]
        [Display(Name = "Name of Video Game:")]
        public string VideoGameName { get; set; }
        [Display(Name = "Video Game Genre:")]
        public VGGenre VideoGameGenre { get; set; }
        [MinLength(1, ErrorMessage = "Must contain at least 1 character...")]
        [MaxLength(1000, ErrorMessage = "Must be within 1000 characters...")]
        [Display(Name = "Video Game Notes:")]
        public string VideoGameNotes { get; set; }
        [Display(Name = "Times Beaten:")]
        public int TimesBeat { get; set; }
    }
}
