using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchBoardStimulation
{
    class Ac : Iappliance
    {
        public int acName { get; set; }
        public Boolean stateAC { get; set; }
        public Ac(int id)
        {
            this.acName = id;
            this.stateAC = false;
        }

        public void StateChange()
        {
            if (stateAC == false)
            {
                stateAC = true;
            }
            else
            {
                stateAC = false;
            }
        }
    }
}
