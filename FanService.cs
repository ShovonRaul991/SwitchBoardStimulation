using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchBoardStimulation
{
    class FanService : IAppliance
    {   
        public List<Fan> fanList = new();
        public FanService() 
        {
            Console.Write("1. Number of Fans: ");
            int fanCount = Convert.ToInt32(Console.ReadLine());
            
            

            for (int i = 1; i <= fanCount; i++)
            {
                fanList.Add(new Fan(i));
            }

        }

        
        public void StateChange(int id)
        {
            var FanEntity = (from fan in fanList
                             where fan.Name == id
                             select fan).ToList();

            if (FanEntity[0].State == "\"Off\"")
            {
                FanEntity[0].State = "\"On\"";
            }
            else
            {
                FanEntity[0].State = "\"Off\"";
            }
        }

        public void AskStateChange(int id)
        {
            var FanEntity = (from fan in fanList
                             where fan.Name == id
                             select fan).ToList();
            if (FanEntity[0].State == "\"Off\"")
            {
                Console.WriteLine("1. Fan" + FanEntity[0].Name.ToString() + " turn \"On\"");
                Console.WriteLine("2. Back");
            }
            else
            {
                Console.WriteLine("1. Fan" + FanEntity[0].Name.ToString() + " turn \"Off\"");
                Console.WriteLine("2. Back");
            }
        }
    }
}
