﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchBoardStimulation
{
    class Bulb : Appliance
    {
        
        public Bulb(int id)
        {
            this.Name = id;
            this.State = "\"Off\"";
        }

        
    }
}
