using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Repositories
{
    public class GameRepository : IGameRepository
    {


        private DICEEntities db;

        public GameRepository(DICEEntities context)
        {
            this.db = context;
        }

        public Game AddGame(Game game)
        {
            db.Games.Add(game);
            db.SaveChanges();
            return game;
        }
        public Game Get(int id)
        {
            return db.Games.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Game> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
