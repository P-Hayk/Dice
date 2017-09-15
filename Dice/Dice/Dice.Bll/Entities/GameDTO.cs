using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.BLL.Entities
{
    public class GameDTO
    {
        public int Id { get; set; }
        public int FirstPlayerID { get; set; }
        public int? SecondPlayerID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
