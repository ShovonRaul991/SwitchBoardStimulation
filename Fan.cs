using System;
using System.Linq;
using System.Collections.Generic;


namespace SwitchBoardStimulation
{
    
    class Fan : Appliance
    {   
        
        public Fan(int id)
        {
            this.Name = id;
            this.State = "\"Off\"";
        }

        
        
    }

}