using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Repositories
{
    public class PlayerCommonRepository : IPlayerCommonRepository
    {
        private DICEEntities db;

        public PlayerCommonRepository(DICEEntities context)
        {
            this.db = context;
        }
        public PlayerCommon AddGame(PlayerCommon game)
        {
            throw new NotImplementedException();
        }
    }
}
