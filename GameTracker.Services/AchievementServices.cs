using GameTracker.Data;
using GameTracker.Models.AchievementModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameTracker.Services
{
    public class AchievementServices
    {
        public bool AchievementAdd(AchievementAdd model)
        {
            var entity = new Achievement()
            {
                VideoGameID = model.VideoGameID,
                VideoGame = model.VideoGame,
                AchievementName = model.AchievementName,
                AchievementNotes = model.AchievementNotes,
                AchievementCompleted = model.AchievementCompleted
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Achievements.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AchievementList> GetAchievements(int videoGameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Achievements.Where(e => e.VideoGameID == videoGameID).Select(e => new AchievementList
                {
                    AchievmentID = e.AchievementID,
                    AchievementName = e.AchievementName,
                    AchievementNotes = e.AchievementNotes,
                    AchievementCompleted = e.AchievementCompleted,
                    VideoGame = e.VideoGame
                });
                return query.ToArray();
            }
        }
        public AchievementDetail AchievementDetails(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Achievements.Single(e => e.AchievementID == id);
                return new AchievementDetail
                {
                    AchievementID = entity.AchievementID,
                    AchievementName = entity.AchievementName,
                    AchievementNotes = entity.AchievementNotes,
                    AchievementCompleted = entity.AchievementCompleted,
                    VideoGame = entity.VideoGame,
                    VideoGameID = entity.VideoGameID
                };
            }
        }
        public bool UpdateAchievement(AchievementEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Achievements.Single(e => e.AchievementID == model.AchievementID && e.VideoGameID == model.VideoGameID);
                entity.AchievementName = model.AchievementName;
                entity.AchievementNotes = model.AchievementNotes;
                entity.AchievementCompleted = model.AchievementCompleted;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAchievement(int achievementID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Achievements.Single(e => e.AchievementID == achievementID);
                ctx.Achievements.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
