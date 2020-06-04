using GameTracker.Data;
using GameTracker.Models.BossModel;
using System.Collections.Generic;
using System.Linq;

namespace GameTracker.Services
{
    public class BossServices
    {
        public bool BossAdd(BossAdd model)
        {
            var entity = new Boss()
            {
                VideoGameID = model.VideoGameID,
                BossName = model.BossName,
                BossNotes = model.BossNotes,
                BossBeaten = model.BossBeaten
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bosses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BossList> GetBosses(int videoGameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Bosses.Where(e => e.VideoGameID == videoGameID).Select(e => new BossList
                {
                    BossID = e.BossID,
                    BossName = e.BossName,
                    BossNotes = e.BossNotes,
                    BossBeaten = e.BossBeaten,
                    VideoGameID = e.VideoGameID,
                    VideoGame = e.VideoGame
                });
                return query.ToArray();
            }
        }
        public BossDetail BossDetails(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bosses.Single(e => e.BossID == id);
                return new BossDetail
                {
                    BossID = entity.BossID,
                    BossName = entity.BossName,
                    BossNotes = entity.BossNotes,
                    BossBeaten = entity.BossBeaten,
                    VideoGame = entity.VideoGame,
                    VideoGameID = entity.VideoGameID
                };
            }
        }
        public bool UpdateBoss(BossEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bosses.Single(e => e.BossID == model.BossID && e.VideoGameID == model.VideoGameID);
                entity.BossName = model.BossName;
                entity.BossNotes = model.BossNotes;
                entity.BossBeaten = model.BossBeaten;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBoss(int bossID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bosses.Single(e => e.BossID == bossID);
                ctx.Bosses.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
