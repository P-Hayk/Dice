using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Repositories
{
    class PlayerSessionRepository : IPlayerSessionRepository
    {
        private DICEEntities db;

        public PlayerSessionRepository(DICEEntities context)
        {
            this.db = context;
        }
        public PlayerSession Add(PlayerSession playerSession)
        {
            db.PlayerSessions.Add(playerSession);
            db.SaveChanges();
            return playerSession;
        }

        public PlayerSession Get(int id)
        {
            throw new NotImplementedException();
        }
        public PlayerSession GetPlayerSession(string token)
        {
            return db.PlayerSessions.FirstOrDefault(x => x.Token == token);
        }

        public IEnumerable<PlayerSession> GetAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteAllPlayerSessions(int playerid)
        {
            List<PlayerSession> list = db.PlayerSessions.Where(x => x.Token != null).ToList();
            list.All(y=> { y.Token = null; return true; });

            db.SaveChanges();

            return playerid;
        }
    }
}
