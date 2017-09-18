using System;

namespace Dice.DTO
{
    public class PlayerSessionDTO
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Token { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
