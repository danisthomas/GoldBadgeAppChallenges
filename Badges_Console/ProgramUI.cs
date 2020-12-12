using Badges_Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    class ProgramUI
    {

        private BadgesRepository _contentBadgesRepository = new BadgesRepository();
        private Badges badge = new Badges();
        public Dictionary<int, string> _badgeDict = new Dictionary<int, string>();
        public List<string> doors = new List<string>();


        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?");
                Console.WriteLine($"1. Add a Badge:\n" +
                    $"2. Edit a Badge\n" +
                    $"3. List All Badges\n" +
                    $"4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Add Badge
                        AddBadgeToList();
                        break;
                    case "2":
                        // Edit Badge
                        UpdateBadge();
                        break;
                    case "3":
                        //List all Badges
                        ListAllBadges();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Have a Great Day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Press enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void AddBadgeToList()
        
        {

            Badges newBadge = new Badges();
            List<string> doorList = new List<string>();
            //doorList = badge.DoorNames;
            newBadge.DoorNames = doorList;

            Console.Clear();
            Console.WriteLine("Enter the Badge Number:");
            int badgeID = int.Parse(Console.ReadLine());
            newBadge.BadgeID = badgeID;

            Console.WriteLine("Enter the Badge Name:");
            string badgeName = Console.ReadLine();
            newBadge.BadgeName = badgeName;
      
            Console.WriteLine("Enter a door the badge needs access to:");
            string doorToAdd = Console.ReadLine();
            doorList.Add(doorToAdd);

                Console.WriteLine("Would you like to add another door? Y or N");
                string addAnotherDoor = Console.ReadLine().ToLower();
            while (addAnotherDoor == "y") 
            {
                

                   
                    Console.WriteLine("Enter a door the badge needs access to:");
                    string nextdoorToAdd = Console.ReadLine();
                    doorList.Add(nextdoorToAdd);

                    Console.WriteLine("Would you like to add another door? Y or N");
                    addAnotherDoor = Console.ReadLine().ToLower();

                
                
            }
            
            _contentBadgesRepository.CreateNewBadge(newBadge);
          
            Console.WriteLine("Press any key to return to Menu:");
            Console.ReadKey();

        }

        public void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the BadgeID you would like to update?\n");
            int badgeIdToUpdate = int.Parse(Console.ReadLine());

             Badges badge = _contentBadgesRepository.GetBadgeByBadgeID(badgeIdToUpdate);
             List<string> currentDoors = badge.DoorNames;
             string s1 = string.Join(",", currentDoors);

            Console.WriteLine($"Badge {badge.BadgeID} has access to doors string {s1}\n");
            Console.WriteLine($"What would you like to do:\n" +
                $"1. Remove the Door\n" +
                $"2. Add a Door.");
            
            int updateDoors = int.Parse(Console.ReadLine());

            
            if (updateDoors == 1 && badge.BadgeID == badgeIdToUpdate)
            {
                
                Console.WriteLine("Enter Door you want to remove:");
                string deleteDoor = Console.ReadLine();
                currentDoors.Remove(deleteDoor);
                string s3 = string.Join(",", currentDoors);

                Console.WriteLine($"{badge.BadgeID} has access to doors {s3}.");
                    
            }
            else
            {
                Console.WriteLine("Enter Door you would like to add:");
                string doorToAdd = Console.ReadLine();
                currentDoors.Add(doorToAdd);
                string s2 = string.Join(",", currentDoors);
                Console.WriteLine($"{badge.BadgeID} has access to doors {s2}.");
            }

        }

        public void ListAllBadges()
        {
           Dictionary<int, Badges> dictOfBadges = _contentBadgesRepository.GetDictOfBadges();


            Console.Clear();
            Console.WriteLine("Badge#:\t\t" + "Door Access");
            foreach (KeyValuePair<int,Badges> badge in dictOfBadges)
            {
                _contentBadgesRepository.GetBadgeByBadgeID(badge.Key);
                List<string> currentdoors = badge.Value.DoorNames;
                string s1 = string.Join(",", currentdoors);

                Console.WriteLine($"{badge.Key}\t\t {s1}");
            }
            
            
               
            


        }

        public void  GetListOfDoors()
        {
            List<string> listOfDoors = _contentBadgesRepository.GetListOfDoors();

            foreach(string doors in listOfDoors)
            {
                Console.WriteLine(doors);
            }
            
        }

        //public void DisplayBadges(Badges badges)
        //{
        //    Dictionary<int, Badges> dictOfBadges = _contentBadgesRepository.GetDictOfBadges();
        //    List<Badges> listOfBadges = _contentBadgesRepository.GetListofBadges();

        //    foreach (KeyValuePair<int, Badges> badge in _badgeDict )
        //    {
        //       if (!_badgeDict.ContainsKey(badge.Key))
        //       {
        //            Console.WriteLine($"{badges.DoorNames)
        //       }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        //Seed List
        public void SeedContentList()
        {
            // List<string> doorList = new List<string>();

            //string badgeOneDoors = "A4";

            // doorList.Add(badgeOneDoors);
           


            Badges badgeOne = new Badges(1234, new List<string> {"A4","B5","C3"}, "John Doe");
            Badges badgeTwo = new Badges(2234, new List<string> { "A1", "B3" }, "Jane Tucker");
            Badges badgeThree = new Badges(4435, new List<string> { "C3", "D2", "A1" }, "Joan Jett");
            _contentBadgesRepository.CreateNewBadge(badgeOne);
            _contentBadgesRepository.CreateNewBadge(badgeTwo);
            _contentBadgesRepository.CreateNewBadge(badgeThree);

            

                
        }
    }
}
