using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceTest
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public IDiceRepository DiceRepo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGameRepository GameRepo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IPlayerRepository PlayerRepo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IPlayerSessionRepository PlayerSessionRepo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IStepRepository StepRepo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
