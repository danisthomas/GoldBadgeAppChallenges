using Greeting_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Console
{
    class ProgramUI
    {
        private GreetingRepository _greetingRepo = new GreetingRepository();
        private List<IGreeting> pastList = new List<IGreeting>();
        private List<IGreeting> currentList = new List<IGreeting>();
        private List<IGreeting> potentialList = new List<IGreeting>();


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
                    "1. Create a New Customer\n" +
                    "2. View List of All Customers\n" +
                    "3. Update an Existing Customer\n" +
                    "4. Delete an Exitsting Customer\n" +
                    "5. Send Email to Past Customers\n" +
                    "6. Send Email to Current Customers\n" +
                    "7. Send Email to Potential Customers\n" +
                    "8. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Create New Customer
                        break;
                    case "2":
                        //View list of All customers
                        break;
                    case "3":
                        //Update existing customer
                        break;
                    case "4":
                        //Delete existing customer
                        break;
                    case "5":
                        //Send Email to Past Customers
                        break;
                    case "6":
                        //Send Email to Current Customer
                        break;
                    case "7":
                        //Send Email to Potential Customers
                        break;
                    case "8":
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
    }
}
