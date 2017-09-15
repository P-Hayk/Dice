using Dice.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.BLL.Entities
{
    public class PlayerSessionDTO
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Token { get; set; }
    }
}
