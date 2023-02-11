using System;
using System.Linq;
using System.Collections.Generic;

namespace SwitchBoardApplication
{
    interface Iappliance
    {
        void stateChange();
    }
    internal class Fan : Iappliance
    {   
        public int fanName { get; set; }
        public Boolean stateFan { get; set; }
        public Fan(int id)
        {
            this.fanName = id;
            this.stateFan = false;
        }

        public void stateChange()
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

    internal class Ac : Iappliance
    {
        public int acName { get; set; }
        public Boolean stateAC { get; set; }
        public Ac(int id)
        {
            this.acName = id;
            this.stateAC = false;
        }

        public void stateChange()
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

    internal class Bulb : Iappliance
    {
        public int bulbName { get; set; }
        public Boolean stateBulb { get; set; }
        public Bulb(int id)
        {
            this.bulbName = id;
            this.stateBulb = false;
        }

        public void stateChange()
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