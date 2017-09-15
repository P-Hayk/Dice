using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dice.DAL.Repositories
{
    public class DiceRepository : IDiceRepository
    {

        private DICEEntities db;

        public DiceRepository(DICEEntities context)
        {
            this.db = context;
        }

        public Dice Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dice> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
