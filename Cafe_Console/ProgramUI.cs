using Challenge_01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace Cafe_Console
{
    class ProgramUI
    {
        private CafeRepository _contentcafeRepo = new CafeRepository();

        public void Run()
        {
            SeedMenuList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create menu Item\n" +
                    "2. View List of Menu Items\n" +
                    "3. Update List of Menu Items\n" +
                    "4. Delete a Meal from Menu\n" +
                    "5. Exit");

                //Get User's input
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Add meals to menu
                        CreateNewMenuItem();
                        break;
                    case "2":
                        //View List of menu items
                        ViewListOfMenuItems();

                        break;
                    case "3":
                        //Update List of Menu Items
                        UpdateListOfMenuItems();
                        break;
                    case "4":
                        //delete menu items
                        DeleteMealFromMenu();
                        break;
                    case "5":
                        Console.WriteLine("Have a Great Day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number.");
                        Console.ResetColor();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Please press any key to continue....");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create New Menu Item

        public void CreateNewMenuItem()
        {
            Console.Clear();
            CafeMenuItems menuItem = new CafeMenuItems();
                Console.WriteLine("Enter Name of New Menu Item:");
            menuItem.Name = Console.ReadLine();

            Console.WriteLine("Enter MenuID: (1,2 3, etc.)");
            menuItem.MenuID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Description of the Menu Item:");
            menuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter List of Ingredients:");
            menuItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter Price of Menu Item:");
             menuItem.Price = double.Parse(Console.ReadLine());

            _contentcafeRepo.AddMealsToMenu(menuItem);
        }

        //View List of Meals on Menu

        public void ViewListOfMenuItems()
        {
            Console.Clear();
            List<CafeMenuItems> listOfMenuItems = _contentcafeRepo.GetListAllMenuItems();
            foreach (CafeMenuItems menuItems in listOfMenuItems)
            {
                Console.WriteLine ($"Meal #: {menuItems.MenuID}\n" +
                    $"Name: {menuItems.Name}\n"+
                    $"Description: {menuItems.Description}\n" +
                    $"List of Ingredients: {menuItems.Ingredients}\n" +
                    $"Price: ${menuItems.Price}\n");
            }
        }

        //Update List of Meal on Menu
        public void UpdateListOfMenuItems()
        {
            Console.Clear();
            ViewListOfMenuItems();
           
            Console.WriteLine("Enter the MealID of the Menu item you would like to update: (1,2,3, etc...)");
            int itemToUpdate = int.Parse(Console.ReadLine());

            CafeMenuItems newMeal = new CafeMenuItems();

            Console.WriteLine("Enter the updated name of the meal:");
            newMeal.Name = Console.ReadLine();

            Console.WriteLine("Enter the updated MealID of the meal:");
            newMeal.MenuID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Updated Description of the Meal:");
            newMeal.Description = Console.ReadLine();

            Console.WriteLine("Enter the updated List of Indgredients of the meal:");
            newMeal.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter the updated Price of the meal: ");
            newMeal.Price = double.Parse(Console.ReadLine());


            bool wasUpdated = _contentcafeRepo.UpdateMenuItemsbyMealId(itemToUpdate, newMeal);
            if (wasUpdated)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Menu item was updated!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not update Menu item.");
                Console.ResetColor();
            }

            ViewListOfMenuItems();

            
        }
        //Delete Meal from Menu

        public void DeleteMealFromMenu()
        {
            Console.Clear();
            ViewListOfMenuItems();

            Console.WriteLine("Enter the MenuID you would like to remove: (1,2,3, etc...)");
            int itemToDelete = int.Parse(Console.ReadLine());

            bool wasDeleted =_contentcafeRepo.RemoveMenuItemsFromList(itemToDelete);

            if (wasDeleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Menu item was successfully removed from the list.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Menu item could not be removed from the list.");
                Console.ResetColor();
            }
        }

        //Seed Method
        private void SeedMenuList() { 

        CafeMenuItems pizza = new CafeMenuItems("Pizza", 1, "Wonderful round goodness!", "Wheat Dough, Tomato Sauce, Cheese, Italian Spices", 8.99);
        CafeMenuItems salad = new CafeMenuItems("Cashew Chichen Salad", 2, "Green Stuff that's good for you!", "Lettuce, Cashews, Chicken, Swiss Cheese",9.99);
        CafeMenuItems hamAndSwissSandwich = new CafeMenuItems("Ham and Swiss Sandwich", 3, "Amazingly great Sandwich!", "Rye Bread, Ham, Swiss, Cheese, Mayo, Lettuce, Tomato", 7.99);

            _contentcafeRepo.AddMealsToMenu(pizza);
            _contentcafeRepo.AddMealsToMenu(salad);
            _contentcafeRepo.AddMealsToMenu(hamAndSwissSandwich);

        }
    }
}
