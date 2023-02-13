using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchBoardStimulation
{
    class Bulb : Iappliance
    {
        public int bulbName { get; set; }
        public Boolean stateBulb { get; set; }
        public Bulb(int id)
        {
            this.bulbName = id;
            this.stateBulb = false;
        }

        public void StateChange()
        {
            if (stateBulb == false)
            {
                stateBulb = true;
            }
            else
            {
                stateBulb = false;
            }
        }
    }
}
