using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Data
{
    public enum VGGenre { Action =1, ActionAdventure, Adventure, RolePlaying, Simulation, Strategy, Sports, Puzzle, Idle }
    public class VideoGame
    {
        [Key]
        public int VideoGameID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string VideoGameName { get; set; }
        public VGGenre VideoGameGenre { get; set; }
        public string VideoGameNotes { get; set; }
        public int TimesBeat { get; set; }
        public ICollection<Quest> Quest { get; set; }
    }
}
