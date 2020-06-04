using GameTracker.Data;
using GameTracker.Models.VideoGameModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameTracker.Services
{
    public class VideoGameServices
    {
        private readonly Guid _vgUserID;
        public VideoGameServices(Guid vgUserID)
        {
            _vgUserID = vgUserID;
        }
        public bool VideoGameAdd(VideoGameAdd model)
        {
            var entity = new VideoGame()
            {
                OwnerID = _vgUserID,
                VideoGameName = model.VideoGameName,
                VideoGameGenre = model.VideoGameGenre,
                VideoGameNotes = model.VideoGameNotes,
                TimesBeat = model.TimesBeat
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.VideoGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<VideoGameList> GetVideoGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.VideoGames.Where(e => e.OwnerID == _vgUserID).Select(e => new VideoGameList
                {
                    VideoGameID = e.VideoGameID,
                    VideoGameName = e.VideoGameName,
                    VideoGameGenre = e.VideoGameGenre,
                    VideoGameNotes = e.VideoGameNotes,
                    TimesBeat = e.TimesBeat
                });
                return query.ToArray();
            }
        }
        public VideoGameDetail VideoGameDetails(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.VideoGames.Single(e => e.VideoGameID == id && e.OwnerID == _vgUserID);
                var entityQuest = ctx.Quests.Where(e => e.VideoGameID == id).ToList();
                var entityInventory = ctx.Inventories.Where(e => e.VideoGameID == id).ToList();
                var entityBoss = ctx.Bosses.Where(e => e.VideoGameID == id).ToList();
                var entityAchievement = ctx.Achievements.Where(e => e.VideoGameID == id).ToList();
                return new VideoGameDetail
                {
                    VideoGameID = entity.VideoGameID,
                    OwnerID = entity.OwnerID,
                    VideoGameName = entity.VideoGameName,
                    VideoGameGenre = entity.VideoGameGenre,
                    VideoGameNotes = entity.VideoGameNotes,
                    TimesBeat = entity.TimesBeat,
                    Quests = (entityQuest == null) ? new List<Quest>() : entityQuest,
                    Inventories = (entityInventory == null) ? new List<Inventory>() : entityInventory,
                    Bosses = (entityBoss == null) ? new List<Boss>() : entityBoss,
                    Achievements = (entityAchievement == null) ? new List<Achievement>() : entityAchievement
                };
            }
        }
        public bool UpdateVideoGame(VideoGameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.VideoGames.Single(e => e.VideoGameID == model.VideoGameID && e.OwnerID == _vgUserID);
                entity.VideoGameName = model.VideoGameName;
                entity.VideoGameGenre = model.VideoGameGenre;
                entity.VideoGameNotes = model.VideoGameNotes;
                entity.TimesBeat = model.TimesBeat;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteVideoGame(int videoGameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.VideoGames.Single(e => e.VideoGameID == videoGameID && e.OwnerID == _vgUserID);
                ctx.VideoGames.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
