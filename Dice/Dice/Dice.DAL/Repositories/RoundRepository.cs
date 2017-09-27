using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice.DAL.Repositories
{
    public class RoundRepository : IRoundRepository
    {

        private DICEEntities db;

        public RoundRepository(DICEEntities context)
        {
            this.db = context;
        }

        public Round Add(Round round)
        {
            db.Rounds.Add(round);
           
            return round;
        }

        public Round Get(int id)
        {
            return db.Rounds.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Round> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
