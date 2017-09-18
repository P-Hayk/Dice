using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dice.DTO

{
    public class StepDTO
    {
        public int Id { get; set; }
        public int  GameId { get; set; }
        public int PlayerId { get; set; }
        public int FirstDice { get; set; }
        public int SecondDice { get; set; }
        public int RoundId { get; set; }
    }
}
