﻿using CompanyOutings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Console
{
    class ProgramUI
    {

        private Golf golfOuting = new Golf();
        private AmusementPark aPOuting = new AmusementPark();
        private Concert concertOuting = new Concert();
        private Bowling bowlingOuting = new Bowling();
        private CompanyOutingsRepository _outingsRepo = new CompanyOutingsRepository();
       // private List<IOutings> listOfOutings = new List<IOutings>();

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please Select a Menu Option:\n" +
                    "1. Display List of Outings\n" +
                    "2. Add Outing to List\n" +
                    "3. Display Total Cost of Outings\n" +
                    "4. Display List of Outings by Type\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Display List of Outings
                        DisplayListOfOutings();

                        break;
                    case "2":
                        //Add Outing to List
                        AddOutingToList();
                        break;
                    case "3":
                        //Display Total Cost of Outings
                      //  TotalCostOfOutings();
                        break;
                    case "4":
                        //Display Cost of Outing by Outing Type
                        TotalCostPerOuting();
                        break;
                    case "5":
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

        public void DisplayListOfOutings()
        {
            List<IOutings> listOfOutings = _outingsRepo.GetListOfOutings();
            Console.Clear();

            Console.WriteLine($"{"Outing:",-25} {"Date:",-25}{"# of People:",-25}{"Cost/Person:",-25}{"Cost/Outing:",-25}");
            foreach (IOutings outings in listOfOutings)
            {
                Console.WriteLine($"{outings.TypeOfOuting,-25}{outings.DateOfOuting.ToShortDateString(),-25} {outings.NumberOfPeople,-25}{outings.CostPerPerson,-25}{outings.CostPerEvent()}");
            }
        }

        public void AddOutingToList()
        {

            List<IOutings> outings = new List<IOutings>();
            var golf = new Golf();
            var bowl = new Bowling();
            var amuse = new AmusementPark();
            var concert = new Concert();


            Console.Clear();
            Console.WriteLine("Enter the Type Of Outing:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            int outingAsInt = int.Parse(Console.ReadLine());





            if (outingAsInt == 1)
            {
                golf.TypeOfOuting = (OutingType)outingAsInt;
              // outings.Add(golf);

                Console.WriteLine("Enter the Date of the Event: (mm/dd/yyyy)");
                DateTime dateinput = DateTime.Parse(Console.ReadLine());
                golf.DateOfOuting= dateinput;
               // outings.Add(golf);


                Console.WriteLine("Enter the Number People who attended the event:");
                int peopleAttended = int.Parse(Console.ReadLine());
                golf.NumberOfPeople = peopleAttended;
               // outings.Add(golf);

                Console.WriteLine("Enter the Cost of the Event per person:");
                double costperperson = double.Parse(Console.ReadLine());
                golf.CostPerPerson=costperperson;
               // outings.Add(golf);

                golf.CostPerEvent();
                _outingsRepo._listOfOutings.Add(golf);
               // outings.Add(golf);
            }
            if (outingAsInt == 2)
            {
                bowl.TypeOfOuting = (OutingType)outingAsInt;
                //outings.Add(bowl);

                Console.WriteLine("Enter the Date of the Event: (mm/dd/yyy)");
                DateTime dateinput = DateTime.Parse(Console.ReadLine());
                bowl.DateOfOuting= dateinput;


                Console.WriteLine("Enter the Number People who attended the event:");
                int peopleAttended = int.Parse(Console.ReadLine());
                bowl.NumberOfPeople= peopleAttended;


                Console.WriteLine("Enter the Cost of the Event per person:");
                double costperperson = double.Parse(Console.ReadLine());
                bowl.CostPerPerson= costperperson;
                bowl.CostPerEvent();
                _outingsRepo._listOfOutings.Add(bowl);
            }
            if (outingAsInt == 3)
            {
                amuse.TypeOfOuting = (OutingType)outingAsInt;
               //outings.Add(amuse);

                Console.WriteLine("Enter the Date of the Event: (mm/dd/yyy)");
                DateTime dateinput = DateTime.Parse(Console.ReadLine());
                amuse.DateOfOuting= dateinput;


                Console.WriteLine("Enter the Number People who attended the event:");
                int peopleAttended = int.Parse(Console.ReadLine());
                amuse.NumberOfPeople= peopleAttended;


                Console.WriteLine("Enter the Cost of the Event per person:");
                double costperperson = double.Parse(Console.ReadLine());
                amuse.CostPerPerson=costperperson;
                amuse.CostPerEvent();
                _outingsRepo._listOfOutings.Add(amuse);
            }
            if (outingAsInt == 4)
            {
                concert.TypeOfOuting = (OutingType)outingAsInt;
                outings.Add(concert);

                Console.WriteLine("Enter the Date of the Event: (mm/dd/yyy)");
                DateTime dateinput = DateTime.Parse(Console.ReadLine());
                concert.DateOfOuting=dateinput;


                Console.WriteLine("Enter the Number People who attended the event:");
                int peopleAttended = int.Parse(Console.ReadLine());
                concert.NumberOfPeople=peopleAttended;


                Console.WriteLine("Enter the Cost of the Event per person:");
                double costperperson = double.Parse(Console.ReadLine());
                concert.CostPerPerson=costperperson;  
                concert.CostPerEvent();
                _outingsRepo._listOfOutings.Add(concert);
            }
        }


        //Helper

        //public void TotalCostOfOutings()
        //{
        //      List<IOutings> listOfOutings = _outingsRepo.GetListOfOutings();
            

        //    foreach (IOutings outings in listOfOutings)
        //    {
        //        double instance = outings.CostPerEvent();
        //        double totalCostOfEvents= outings.CostPerEvent()*
                
        //        Console.WriteLine($"Total Cost of outings is:  {totalCostOfEvents}. ");
        //    }
            

        //}
        public void TotalCostPerOuting()
        {
            List<IOutings> listOfOutings = _outingsRepo.GetListOfOutings();
            Console.WriteLine("Enter the Type Of Outing:\n" +
           "1. Golf\n" +
           "2. Bowling\n" +
           "3. Amusement Park\n" +
           "4. Concert");

            int type = int.Parse(Console.ReadLine());

          
            
                foreach (IOutings outings in listOfOutings)
                {
                    if(type == 1 && outings.TypeOfOuting== OutingType.Golf)
                    {
                        Console.WriteLine($"The Total Cost for the Golf Events was: ${outings.CostPerEvent()}.");
                    }
                    if (type == 2 && outings.TypeOfOuting == OutingType.Bowling)
                    {
                    double TotalCostPerEvent = (bowlingOuting.CostPerPerson * bowlingOuting.NumberOfPeople);
                    Console.WriteLine($"The Total Cost for the Bowling Events was: ${outings.CostPerEvent()}.");
                    }
                    if (type == 3 && outings.TypeOfOuting == OutingType.AmusePark)
                    {
                    double TotalCostPerEvent = (aPOuting.CostPerPerson * aPOuting.NumberOfPeople);
                    Console.WriteLine($"The Total Cost for the Amusement Park Events was: ${TotalCostPerEvent}.");
                    }
                    if (type == 4 && outings.TypeOfOuting == OutingType.Concert)
                    {
                    double TotalCostPerEvent = (concertOuting.CostPerPerson * concertOuting.NumberOfPeople);
                    Console.WriteLine($"The Total Cost for the Concert Events was: ${TotalCostPerEvent}.");
                    }
                }
                    
               

            
           
           
          
        }

        //Seed List
        private void SeedContentList()
        {
            var golf = new Golf();
            var bowl = new Bowling();
            var amuse = new AmusementPark();
            var concert = new Concert();
           
            golf.CostPerPerson = 60;
            golf.DateOfOuting = new DateTime(2019,03,23);
            golf.NumberOfPeople = 300;
            golf.TypeOfOuting = OutingType.Golf;
            golf.CostPerEvent();
            bowl.CostPerPerson = 20;
            bowl.DateOfOuting = new DateTime(2019,4,20);
            bowl.NumberOfPeople = 100;
            bowl.TypeOfOuting = OutingType.Bowling;
            bowl.CostPerEvent();
            amuse.CostPerPerson = 200;
            amuse.NumberOfPeople = 250;
            amuse.DateOfOuting = new DateTime(2019,05,22);
            amuse.TypeOfOuting = OutingType.AmusePark;
            amuse.CostPerEvent();
            concert.CostPerPerson = 90;
            concert.NumberOfPeople = 150;
            concert.DateOfOuting = new DateTime(2019,06,02);
            concert.TypeOfOuting = OutingType.Concert;
            concert.CostPerEvent();

            _outingsRepo._listOfOutings.Add(golf);
            _outingsRepo._listOfOutings.Add(bowl);
            _outingsRepo._listOfOutings.Add(amuse);
            _outingsRepo._listOfOutings.Add(concert);

            

        }
        
    }
}
