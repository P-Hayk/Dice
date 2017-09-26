using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private DICEEntities db;

        public PlayerRepository(DICEEntities context)
        {
            this.db = context;
        }
        public Player Add(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return player;
        }

        public Player Get(int id)
        {
            Player player= db.Players.Where(x => x.Id == id).FirstOrDefault();
            return player;
        }

        public Player Get(string userName)
        {
            Player player=db.Players.FirstOrDefault(x => x.UserName == userName);
            return player;
        }

        public IEnumerable<Player> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
