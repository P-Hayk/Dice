﻿using Dice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IPlayerRepository playerRepo;
        private IGameRepository gameRepo;
        private IStepRepository stepRepo;
        private IDiceRepository diceRepo;
        private IPlayerSessionRepository playerSessionRepo;
        private IPlayerCommonRepository playerCommonRepo;
        private IRoundRepository roundRepo;
        private DICEEntities db;

        private bool disposed = false;
        public UnitOfWork()
        {
            db = new DICEEntities();
        }
        public IPlayerCommonRepository PlayerCommonRepo
        {
            get
            {
                if (playerCommonRepo == null)
                    playerCommonRepo = new PlayerCommonRepository(db);
                return playerCommonRepo;
            }

        }

        public IPlayerRepository PlayerRepo
        {
            get
            {
                if (playerRepo == null)
                    playerRepo = new PlayerRepository(db);
                return playerRepo;
            }

        }

        public IGameRepository GameRepo
        {
            get
            {
                if (gameRepo == null)
                    gameRepo = new GameRepository(db);
                return gameRepo;
            }

        }

        public IDiceRepository DiceRepo
        {
            get
            {
                if (diceRepo == null)
                    diceRepo = new DiceRepository(db);
                return diceRepo;
            }

        }

        public IPlayerSessionRepository PlayerSessionRepo
        {
            get
            {
                if (playerSessionRepo == null)
                    playerSessionRepo = new PlayerSessionRepository(db);
                return playerSessionRepo;
            }

        }

        public IStepRepository StepRepo
        {
            get
            {
                if (stepRepo == null)
                    stepRepo = new StepRepository(db);
                return stepRepo;
            }

        }

        public IRoundRepository RoundRepo
        {
            get
            {
                if (roundRepo == null)
                    roundRepo = new RoundRepository(db);
                return roundRepo;
            }

        }

        public void Save()
        {
            db.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
