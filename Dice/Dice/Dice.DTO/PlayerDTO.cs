﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DTO
{
    public class PlayerDTO
    {
        public int? Id { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }

    }
}