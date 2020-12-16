using Greeting_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        private Customer customer = new Customer();

        public void Run()
        {
            SeedList();
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
                        CreateNewCustomer();
                        break;
                    case "2":
                        //View list of All customers
                        ViewListOfAllCustomers();
                        break;
                    case "3":
                        //Update existing customer
                        UpdateListOfCustomers();
                        break;
                    case "4":
                        //Delete existing customer
                        DeleteExistingCustomer();
                        break;
                    case "5":
                        //Send Email to Past Customers
                        SendEmailToPastCustomers();
                        break;
                    case "6":
                        //Send Email to Current Customer
                        SendEmailToCurrentCustomers();
                        break;
                    case "7":
                        //Send Email to Potential Customers
                        SendEmailToPotentialCustomers();
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
        public void CreateNewCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();

            Console.WriteLine("Enter the Customer's ID:");
            newCustomer.CustomerID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Customer's First Name:");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the Customer's Last Name:");
            newCustomer.LastName = Console.ReadLine();

            Console.WriteLine("Enter the Customer's Email Address:");
            newCustomer.Email = Console.ReadLine();

            Console.WriteLine("Enter the Customer's last invoice Date:");
            DateTime input= Convert.ToDateTime(Console.ReadLine());
                      
            newCustomer.LastInvoice = input;
            newCustomer.TypeOfCustomer = customer.GetTimeSpan(newCustomer);

            _greetingRepo.AddNewCustomer(newCustomer);
        }

        public void UpdateListOfCustomers()
        {
            Console.Clear();
            ViewListOfAllCustomers();
            Console.WriteLine("Enter the CustomerID you would like to update: 1, 2,3,etc");
            int customerToUpdate = int.Parse(Console.ReadLine());

            Customer updatedCustomer = new Customer();

            Console.WriteLine("Enter the updated First Name:");
            updatedCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the Updated Last Name:");
            updatedCustomer.LastName = Console.ReadLine();

            Console.WriteLine("Enter Updated Email address.");
            updatedCustomer.Email = Console.ReadLine();

            Console.WriteLine("enter updated LastInvoice date (mm/dd/yyyy)");
            updatedCustomer.LastInvoice = DateTime.Parse(Console.ReadLine());
            
            customer.TypeOfCustomer = customer.GetTimeSpan(updatedCustomer);
          
            bool wasUpdated = _greetingRepo.UpdateCustomerByID(customerToUpdate, updatedCustomer);
            if(wasUpdated)  
            {
                Console.WriteLine("Customer was successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update Customer.");
            }
        }
        public void DeleteExistingCustomer()
        {
            Console.Clear();
            ViewListOfAllCustomers();

            Console.WriteLine("Enter the CustomerID you would like to remove: (1,2,3, etc...)");
            int customerToDelete = int.Parse(Console.ReadLine());

            bool wasDeleted = _greetingRepo.RemoveCustomersFromList(customerToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("The Customer was successfully removed from the list.");
            }
            else
            {
                Console.WriteLine("The Customer could not be removed from the list.");
            }
        }
        public void SendEmailToPastCustomers()
        {

            if (customer.TypeOfCustomer == CustomerType.Past)
            {
                _greetingRepo.AddCustomerToCorrectList();
            }


                    foreach (IGreeting customer in pastList)
                    {                
                        SmtpClient cv = new SmtpClient("smtp.live.com", 25);
                        cv.EnableSsl = true;
                        cv.Credentials = new NetworkCredential("email", "password");
                    try
                    {
                        cv.Send($"sender email", customer.Email, "Please come Back", "It's been a long time since we've heard from you!");
                        Console.WriteLine("Email sent successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Email can't send successfully under below reasons");
                        Console.WriteLine(ex.Message);
                    }
                    }
            
        }

        public void SendEmailToCurrentCustomers()
        {

            if(customer.TypeOfCustomer == CustomerType.Current)
            {
                _greetingRepo.AddCustomerToCorrectList();
            }

            foreach (IGreeting customer in currentList)
            {

                SmtpClient cv = new SmtpClient("smtp.live.com", 25);
                cv.EnableSsl = true;
                cv.Credentials = new NetworkCredential("email", "password");
                try
                {
                    cv.Send($"sender email", customer.Email, "Thank You!", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon!");
                    Console.WriteLine("email sent successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Email can't send successfully underr below reasons");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void SendEmailToPotentialCustomers()

        {
            if (customer.TypeOfCustomer == CustomerType.Potential)
            {
                _greetingRepo.AddCustomerToCorrectList();
            }
            foreach (IGreeting customer in potentialList)
            {

                SmtpClient cv = new SmtpClient("smtp.live.com", 25);
                cv.EnableSsl = true;
                cv.Credentials = new NetworkCredential("email", "password");
                try
                {
                    cv.Send($"sender email", customer.Email, "Hello!", "We currently have the lowest rates on Helicopter Insurance!");
                    Console.WriteLine("email sent successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Email can't send successfully under below reasons");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void ViewListOfAllCustomers()
        {
            Console.Clear();

            List<IGreeting> listOfAllCustomers = _greetingRepo.GetListOfAllCustomers();
            _greetingRepo.AssignEmailType();
            Console.WriteLine($"{"Customer ID:",-25}{"First Name",-25}{"Last Name",-25}{"Type",-25}{"Email",-25}\n");
            foreach (IGreeting customer in listOfAllCustomers)
            {                
                Console.WriteLine($"{customer.CustomerID,-25}{customer.FirstName,-25}{customer.LastName,-25}{customer.TypeOfCustomer,-25}{customer.EmailType,-25}" );
            }
        }
        //Seed List
        private void SeedList()
        {
            var customer1 = new Customer();
            var customer2 = new Customer();
            var customer3 = new Customer();

            customer1.CustomerID = 1;
            customer1.FirstName = "Jane";
            customer1.LastName = "Doe";
            customer1.Email = "JDoe@hotmail.com";
            customer1.LastInvoice = new DateTime(2019, 02, 13);

            customer2.CustomerID = 2;
            customer2.FirstName = "Joan";
            customer2.LastName = "Jett";
            customer2.Email = "JJett@hotmail.com";
            customer2.LastInvoice = new DateTime(2020, 12, 01);
 
            customer3.CustomerID = 3;
            customer3.FirstName = "John";
            customer3.LastName = "Doe";
            customer3.Email = "JDoe@gmail.com";

            _greetingRepo.AddNewCustomer(customer1);
            _greetingRepo.AddNewCustomer(customer2);
            _greetingRepo.AddNewCustomer(customer3);
            customer1.TypeOfCustomer = customer.GetTimeSpan(customer1);
            customer2.TypeOfCustomer = customer.GetTimeSpan(customer2);
            customer3.TypeOfCustomer = customer.GetTimeSpan(customer3);

        }
         
    }
}
