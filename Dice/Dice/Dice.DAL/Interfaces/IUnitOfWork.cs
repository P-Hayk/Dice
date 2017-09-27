using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository PlayerRepo { get; }
        IGameRepository GameRepo { get; }
        IDiceRepository DiceRepo { get; }
        IPlayerSessionRepository PlayerSessionRepo { get; }
        IStepRepository StepRepo { get; }
        IRoundRepository RoundRepo { get; }
        void Save();
    }
}
