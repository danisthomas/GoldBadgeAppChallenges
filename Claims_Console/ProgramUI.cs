using Claims_Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    class ProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();

        private Claims claim = new Claims();
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
                Console.WriteLine("Select a menu option:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //See all Claims
                        ListAllClaims();
                        break;
                    case "2":
                        //Take Care of next claim
                        TakeCareOfNextClaim();

                        break;
                    case "3":
                        //Enter new claim
                        AddNewClaim();
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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Press any key to continue.....");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();

            }

        }
        private void ListAllClaims()
        {
            List<Claims> listOfClaims = _claimsRepo.GetListOfClaims();
            Console.Clear();
            Console.WriteLine($"{"ClaimID:"}  {"Type:"}\t  {"Description:"}\t{"Amount:"}\t{"DateOfIncident:"}\t{"DateOfClaim:"}\tIsValid:");

            foreach (Claims claim in listOfClaims)
            {

                Console.WriteLine($"{claim.ClaimID}\t  {claim.TypeOfClaim}\t  {claim.Description}\t{claim.ClaimAmount}\t{claim.DateOfIncident.ToShortDateString()}\t{claim.DateOfClaim.ToShortDateString()}\t{claim.IsValid}");
            }






        }

        private void TakeCareOfNextClaim()
        {
            Queue<Claims> claimsQueue = _claimsRepo.GetQueueOfClaims();
            
            {
                
                {
                    Claims peekClaim = claimsQueue.Peek();
                    List<Claims> claim = _claimsRepo.GetListOfClaims();
                    Console.Clear();

                    Console.WriteLine($"Here are the details for the next claim to be handled:\n");

                    Console.WriteLine($"ClaimID: {peekClaim.ClaimID}\n" +
                        $"Type: {peekClaim.TypeOfClaim}\n" +
                        $"Description: {peekClaim.Description}\n" +
                        $"Amount: {peekClaim.ClaimAmount}\n" +
                        $"DateOfIncident: {peekClaim.DateOfIncident.ToShortDateString()}\n" +
                        $"DateOfClaim: {peekClaim.DateOfClaim.ToShortDateString()}\n" +
                        $"IsValid: {peekClaim.IsValid}\n");
                }

                Console.WriteLine("Do you want to deal with this claim now? Y or N");
                string useFirstClaim = (Console.ReadLine().ToLower());
                if(useFirstClaim == "y")
                {
                    
                    _claimsRepo.DeleteClaimFromList();
                    claimsQueue.Dequeue();
                }
                Console.Clear();
                while (useFirstClaim == "y" && claimsQueue.Count > 0)
                {

                    
                    Claims peekClaim = claimsQueue.Peek();
                    List<Claims> claim = _claimsRepo.GetListOfClaims();
                    Console.WriteLine($"Here are the details for the next claim to be handled:\n");

                    Console.WriteLine($"ClaimID: {peekClaim.ClaimID}\n" +
                        $"Type: {peekClaim.TypeOfClaim}\n" +
                        $"Description: {peekClaim.Description}\n" +
                        $"Amount: {peekClaim.ClaimAmount}\n" +
                        $"DateOfIncident: {peekClaim.DateOfIncident.ToShortDateString()}\n" +
                        $"DateOfClaim: {peekClaim.DateOfClaim.ToShortDateString()}\n" +
                        $"IsValid: {peekClaim.IsValid}\n");

                    Console.WriteLine("Do you want to deal with this claim now? Y or N");
                    string useSecondClaim = (Console.ReadLine().ToLower());
                    if (useSecondClaim == "y")
                    {

                        _claimsRepo.DeleteClaimFromList();
                        claimsQueue.Dequeue();
                    }
                    else
                    {
                       // Console.WriteLine("Press any key to return to the menu:");
                       // Console.ReadKey();
                        useFirstClaim = "n";
                    }
                    
                    Console.Clear();

                }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Press any key to return to the menu:");
                    Console.ResetColor();
                    Console.ReadKey();

            }

        }
        private void AddNewClaim()
        {
            Claims newContent = new Claims();
            

            Console.WriteLine("Enter the Claim ID:");
            int claimID = int.Parse(Console.ReadLine());
            newContent.ClaimID = claimID;

            Console.WriteLine("Enter the Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int typeOfClaimAsInt = int.Parse(Console.ReadLine());
            newContent.TypeOfClaim = (ClaimType)typeOfClaimAsInt;

            Console.WriteLine("Enter a Claim Description:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage:");
            newContent.ClaimAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Date of Incident: ie:(mm/dd/yyyy)");
            newContent.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Date of Claim: ie:(mm/dd/yyyy)");
            newContent.DateOfClaim = DateTime.Parse(Console.ReadLine());

            DateTime claimdate = newContent.DateOfClaim.Date;
            DateTime incidentdate = newContent.DateOfIncident.Date;
            TimeSpan tsdiff = claimdate.Subtract(incidentdate);

            
            if (tsdiff.Days <= 30)
            {
                newContent.IsValid = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This Claim is Valid.");
                Console.ResetColor();
               
            }
            else
            {
                newContent.IsValid = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This claim is not Valid.");
                Console.ResetColor();
            }
            _claimsRepo.AddClaimsToList(newContent);
            


        }


        //SeedMethod
        private void SeedContentList()
        {
            DateTime oneClaim = new DateTime(2020, 6, 20);
            DateTime oneIncident = new DateTime(2020, 6, 15);
            DateTime twoClaim = new DateTime(2020, 3, 01);
            DateTime twoIncident = new DateTime(2020, 1, 15);
            DateTime threeClaim = new DateTime(2020, 2, 22);
            DateTime threeIncident = new DateTime(2020, 2, 28);
            


            Claims one = new Claims(1, ClaimType.Car, "Car accident", 5000, oneIncident, oneClaim , true);
            Claims two = new Claims(2, ClaimType.Home, "Lightening", 2000, twoIncident, twoClaim,false);
            Claims three = new Claims(3, ClaimType.Theft, "Break-in", 2500, threeIncident, threeClaim, true);

            _claimsRepo.AddClaimsToList(one);
            _claimsRepo.AddClaimsToList(two);
            _claimsRepo.AddClaimsToList(three);

        }






    }





}




