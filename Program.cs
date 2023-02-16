using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace SwitchBoardStimulation
{
    class Program
    {
        public static void Main()
        {

            FanService fanService = new();
            AcService acService = new();
            BulbService bulbService = new();

            var fanList = fanService.fanList;
            var acList = acService.acList;
            var bulbList = bulbService.bulbList;

            CheckState(fanList, acList, bulbList);
            MenuShow(fanList, acList, bulbList);
            var selectedThing = Convert.ToInt32(Console.ReadLine());
            UseItem(selectedThing, fanService, acService, bulbService);
            //Console.WriteLine(selectedItem);


        }


        //  TURN ON OR TURN OFF THE SELECTED ITEM
        public static void UseItem(int id, FanService fanService, AcService acService, BulbService bulbService)
        {
            var fanList = fanService.fanList;
            var acList = acService.acList;
            var bulbList = bulbService.bulbList;
            while (id > fanList.Count + acList.Count + bulbList.Count || id < 1) 
            {
                System.Console.WriteLine("Plese enter the correct value among the given menu: ");
                NextInput(fanService,acService,bulbService);
                
            }
            if (id <= fanList.Count)
            {
                var tempFan = (from fan in fanList
                              where fan.Name == id
                              select fan).ToList();
                fanService.AskStateChange(tempFan[0].Name);
                var selectedOption = Convert.ToUInt32(Console.ReadLine());
                if (selectedOption == 1)
                {
                    fanService.StateChange(tempFan[0].Name);
                    NextInput(fanService, acService, bulbService);

                }
                else if(selectedOption == 2)
                {
                    NextInput(fanService, acService, bulbService);
                }
                
            }

            else if(id>fanList.Count && id<=fanList.Count+acList.Count) 
            {
                var tempAc = (from ac in acList
                              where ac.Name == id - fanList.Count
                              select ac).ToList();
                acService.AskStateChange(tempAc[0].Name);
                var selectedOption = Convert.ToUInt32(Console.ReadLine());
                if (selectedOption == 1)
                {
                    acService.StateChange(tempAc[0].Name);
                    NextInput(fanService, acService, bulbService);

                }
                else if (selectedOption == 2)
                {
                    NextInput(fanService, acService, bulbService);
                }
            }
            else
            {
                var tempBulb = (from bulb in bulbList
                                where bulb.Name == id - fanList.Count - acList.Count
                                select bulb).ToList();
                bulbService.AskStateChange(tempBulb[0].Name);
                var selectedOption = Convert.ToUInt32(Console.ReadLine());
                if (selectedOption == 1)
                {
                    bulbService.StateChange(tempBulb[0].Name);
                    NextInput(fanService, acService, bulbService);

                }
                else if (selectedOption == 2)
                {
                    NextInput(fanService, acService, bulbService);
                }
            }
        }
        

        //    MENU CREATING FUNCTION
        public static void MenuShow(List<Fan> fanList, List<Ac> acList, List<Bulb> bulbList)
        {
            int id = 1;
            var listFan = from fan in fanList select "Fan "+fan.Name;
            var listAc = from ac in acList select "AC "+ac.Name;
            var listbulb = from bulb in bulbList select "bulb "+bulb.Name;
            Console.WriteLine();
            Console.WriteLine("Here is the list of items you can Choose: ");
            foreach(var f in listFan)
            {
                Console.WriteLine(id+". "+f.ToString());
                id++;
                
            }
            foreach (var f in listAc)
            {
                Console.WriteLine(id + ". " + f.ToString());
                id++;
            }
            foreach (var f in listbulb)
            {
                Console.WriteLine(id + ". " + f.ToString());
                id++;
            }
            Console.WriteLine("Select one appliance from them: ");
            
        }
        

        // STATUS SHOWING FUNCTION OF ELECTRIC ITEMS
        public static void CheckState(List<Fan> fanList,List<Ac> acList,List<Bulb> bulbList)
        {
            var fanListDetails = from fan in fanList
                                 select "Fan " + fan.Name + " is " + fan.State;
                                 
            var acListDetails = from ac in acList
                                select "AC " + ac.Name + " is "+ac.State;
                                
            var bulbListDetails = from bulb in bulbList
                                  select "Bulb " + bulb.Name + " is "+bulb.State;
                                  

            Console.WriteLine();
            foreach (var result in fanListDetails)
            {
                Console.WriteLine(result);
            }
            foreach (var result in acListDetails)
            {
                Console.WriteLine(result);
            }
            foreach (var result in bulbListDetails)
            {
                Console.WriteLine(result);
            }
        }

        public static void NextInput(FanService fanService, AcService acService, BulbService bulbService)
        {
            var fanList = fanService.fanList;
            var acList = acService.acList;
            var bulbList = bulbService.bulbList;
            CheckState(fanList, acList, bulbList);
            MenuShow(fanList, acList, bulbList);
            var selectedItem = Convert.ToInt32(Console.ReadLine());
            UseItem(selectedItem, fanService, acService, bulbService);
        }
        
    }
}
