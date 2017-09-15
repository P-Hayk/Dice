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

        public IEnumerable<PlayerSession> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
