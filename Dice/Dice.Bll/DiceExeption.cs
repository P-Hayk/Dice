using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.Bll
{
    public class DiceException : Exception
    {
        public int Id { get; set; }

        public DiceException(string message)
            : base(message)
        { }
        public DiceException(int errorCode, string message)
            : base(message)
        {
            Id = errorCode;
        }
    }
}
