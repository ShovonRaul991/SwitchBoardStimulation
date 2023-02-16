using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchBoardStimulation
{
    interface IAppliance
    {
        void StateChange(int id);
        void AskStateChange(int id);
    }
    
}
