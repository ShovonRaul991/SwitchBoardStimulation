using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;

namespace SwitchBoardApplication
{
    class Program
    {
        public static void Main()
        {
            Console.Write("1. Number of Fans: ");
            int fanCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("2. Number of ACs: ");
            int acCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("3. Number of bulbs: ");
            int bulbCount = Convert.ToInt32(Console.ReadLine());


            //created the fan appliances
            List<Fan> fanList = new();

            for(int i=1;i<=fanCount;i++)
            {
                fanList.Add(new Fan(i));
            }

            //created the AC appliances
            List<Ac> acList = new();

            for (int i = 1; i <= acCount; i++)
            {
                acList.Add(new Ac(i));
            }

            //created the AC appliances
            List<Bulb> bulbList = new();

            for (int i = 1; i <= bulbCount; i++)
            {
                bulbList.Add(new Bulb(i));
            }

            checkState(fanList, acList, bulbList);
            menuShow(fanList, acList, bulbList);
            var selectedThing = Convert.ToInt32(Console.ReadLine());
            useItem(selectedThing, fanList, acList, bulbList);
            //Console.WriteLine(selectedItem);


        }


        //  TURN ON OR TURN OFF THE SELECTED ITEM
        public static void useItem(int id, List<Fan> fanList, List<Ac> acList, List<Bulb> bulbList)
        {   
            if (id <= fanList.Count)
            {
                var tempFan = (from fan in fanList
                              where fan.fanName == id
                              select fan).ToList();
                Console.WriteLine("1. Fan" + tempFan[0].fanName.ToString()+" is " + !(tempFan[0].stateFan));
                Console.WriteLine("2. Back");
                var selectedOption = Convert.ToUInt32(Console.ReadLine());
                if (selectedOption == 1)
                {
                    tempFan[0].stateChange();
                    nextInput(fanList, acList, bulbList);
                    
                }
                else if(selectedOption == 2)
                {
                    nextInput(fanList, acList, bulbList);
                }
            }

            else if(id>fanList.Count && id<=fanList.Count+acList.Count) 
            {
                var tempAc = (from ac in acList
                              where ac.acName == id - fanList.Count()
                              select ac).ToList();
                Console.WriteLine("1. AC" + tempAc[0].acName.ToString() + " is " + !(tempAc[0].stateAC));
                Console.WriteLine("2. Back");
                var selectedOption = Convert.ToUInt32(Console.ReadLine());
                if (selectedOption == 1)
                {
                    tempAc[0].stateChange();
                    nextInput(fanList, acList, bulbList);

                }
                else if (selectedOption == 2)
                {
                    nextInput(fanList, acList, bulbList);
                }
            }
            else
            {
                var tempBulb = (from bulb in bulbList
                                where bulb.bulbName == id - fanList.Count() - acList.Count()
                                select bulb).ToList();
                Console.WriteLine("1. Bulb" + tempBulb[0].bulbName.ToString() + " is " + !(tempBulb[0].stateBulb));
                Console.WriteLine("2. Back");
                var selectedOption = Convert.ToUInt32(Console.ReadLine());
                if (selectedOption == 1)
                {
                    tempBulb[0].stateChange();
                    nextInput(fanList, acList, bulbList);

                }
                else if (selectedOption == 2)
                {
                    nextInput(fanList, acList, bulbList);
                }
            }
        }
        

        //    MENU CREATING FUNCTION
        public static void menuShow(List<Fan> fanList, List<Ac> acList, List<Bulb> bulbList)
        {
            int id = 1;
            var listFan = from fan in fanList select "Fan "+fan.fanName;
            var listAc = from ac in acList select "AC "+ac.acName;
            var listbulb = from bulb in bulbList select "bulb "+bulb.bulbName;
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
        public static void checkState(List<Fan> fanList,List<Ac> acList,List<Bulb> bulbList)
        {
            var fanListDetails = (from fan in fanList
                                 where fan.stateFan is false
                                 select "Fan " + fan.fanName + " is \"Off\"")
                                 .Union(from fan in fanList
                                        where fan.stateFan is true
                                        select "Fan " + fan.fanName + " is \"On\"");
            var acListDetails = (from ac in acList
                                where ac.stateAC is false
                                select "AC " + ac.acName + " is \"Off\"")
                                .Union(from ac in acList
                                       where ac.stateAC is true
                                       select "AC " + ac.acName + " is \"On\"");
            var bulbListDetails = (from bulb in bulbList
                                  where bulb.stateBulb is false
                                  select "Bulb " + bulb.bulbName + " is \"Off\"")
                                  .Union(from bulb in bulbList
                                         where bulb.stateBulb is true
                                         select "Bulb " + bulb.bulbName + " is \"On\"");

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

        public static void nextInput(List<Fan> fanList, List<Ac> acList, List<Bulb> bulbList)
        {
            checkState(fanList, acList, bulbList);
            menuShow(fanList, acList, bulbList);
            var selectedItem = Convert.ToInt32(Console.ReadLine());
            useItem(selectedItem, fanList, acList, bulbList);
        }
        
    }
}
