using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DTO
{
    class PlayerCommonDTO
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GamesCount { get; set; }
        public int WonsGames { get; set; }
        public int LostGames { get; set; }
    }
}
