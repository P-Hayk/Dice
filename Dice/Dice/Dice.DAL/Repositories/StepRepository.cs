using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Repositories
{
    class StepRepository : IStepRepository
    {
        private DICEEntities db;

        public StepRepository(DICEEntities context)
        {
            this.db = context;
        }

        public Step Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Step> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
