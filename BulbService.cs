using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchBoardStimulation
{
    class BulbService:IAppliance
    {

        public List<Bulb> bulbList = new();
        public BulbService() 
        {
            Console.Write("3. Number of bulbs: ");
            int bulbCount = Convert.ToInt32(Console.ReadLine());


            for (int i = 1; i <= bulbCount; i++)
            {
                bulbList.Add(new Bulb(i));
            }
        }
        public void StateChange(int id)
        {
            var BulbEntity = (from bulb in bulbList
                             where bulb.Name == id
                             select bulb).ToList();
            if (BulbEntity[0].State == "\"Off\"")
            {
                BulbEntity[0].State = "\"On\"";
            }
            else
            {
                BulbEntity[0].State = "\"Off\"";
            }
        }

        public void AskStateChange(int id)
        {
            var BulbEntity = (from bulb in bulbList
                              where bulb.Name == id
                              select bulb).ToList();
            if (BulbEntity[0].State == "\"Off\"")
            {
                Console.WriteLine("1. Bulb" + BulbEntity[0].Name.ToString() + " turn \"On\"");
                Console.WriteLine("2. Back");
            }
            else
            {
                Console.WriteLine("1. Bulb" + BulbEntity[0].Name.ToString() + " turn \"Off\"");
                Console.WriteLine("2. Back");
            }
        }
    }
}
