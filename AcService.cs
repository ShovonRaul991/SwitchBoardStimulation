using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchBoardStimulation
{
    class AcService:IAppliance
    {
        public List<Ac> acList = new();

        public AcService() 
        {
            Console.Write("2. Number of ACs: ");
            int acCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= acCount; i++)
            {
                acList.Add(new Ac(i));
            }
        }
        public void StateChange(int id)
        {
            var AcEntity = (from ac in acList
                             where ac.Name == id
                             select ac).ToList();
            if (AcEntity[0].State == "\"Off\"")
            {
                AcEntity[0].State = "\"On\"";
            }
            else
            {
                AcEntity[0].State = "\"Off\"";
            }
        }

        public void AskStateChange(int id)
        {
            var AcEntity = (from ac in acList
                            where ac.Name == id
                            select ac).ToList();
            if (AcEntity[0].State == "\"Off\"")
            {
                Console.WriteLine("1. AC" + AcEntity[0].Name.ToString() + " turn \"On\"");
                Console.WriteLine("2. Back");
            }
            else
            {
                Console.WriteLine("1. AC" + AcEntity[0].Name.ToString() + " turn \"Off\"");
                Console.WriteLine("2. Back");
            }
        }
    }
}
