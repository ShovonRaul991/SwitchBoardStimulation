using System;
using System.Linq;
using System.Collections.Generic;


namespace SwitchBoardStimulation
{
    
    class Fan : Iappliance
    {   
        public int fanName { get; set; }
        public Boolean stateFan { get; set; }
        public Fan(int id)
        {
            this.fanName = id;
            this.stateFan = false;
        }

        public void StateChange()
        {
            
            if(stateFan==false)
            {
                stateFan = true;
            }
            else
            {
                stateFan = false;
            }
        }
        
    }

}