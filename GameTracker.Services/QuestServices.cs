using GameTracker.Data;
using GameTracker.Models.QuestModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameTracker.Services
{
    public class QuestServices
    {
        public bool QuestAdd(QuestAdd model)
        {
            var entity = new Quest()
            {
                VideoGameID = model.VideoGameID,
                VideoGame = model.VideoGame,
                QuestName = model.QuestName,
                QuestNotes = model.QuestNotes,
                MainQuest = model.MainQuest,
                QuestComplete = model.QuestComplete
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Quests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<QuestList> GetQuests(int videoGameID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Quests.Where(e => e.VideoGameID == videoGameID).Select(e => new QuestList
                {
                    QuestID = e.QuestID,
                    QuestName = e.QuestName,
                    QuestNotes = e.QuestNotes,
                    MainQuest = e.MainQuest,
                    QuestComplete = e.QuestComplete,
                    VideoGame = e.VideoGame
                });
                return query.ToArray();
            }
        }
        public QuestDetail QuestDetails(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Quests.Single(e => e.QuestID == id);
                return new QuestDetail
                {
                    QuestID = entity.QuestID,
                    QuestName = entity.QuestName,
                    QuestNotes = entity.QuestNotes,
                    MainQuest = entity.MainQuest,
                    QuestComplete = entity.QuestComplete,
                    VideoGame = entity.VideoGame,
                    VideoGameID = entity.VideoGameID
                };
            }
        }
        public bool UpdateQuest(QuestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Quests.Single(e => e.QuestID == model.QuestID && e.VideoGameID == model.VideoGameID);
                entity.QuestName = model.QuestName;
                entity.QuestNotes = model.QuestNotes;
                entity.MainQuest = model.MainQuest;
                entity.QuestComplete = model.QuestComplete;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteQuest(int questID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Quests.Single(e => e.QuestID == questID);
                ctx.Quests.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
