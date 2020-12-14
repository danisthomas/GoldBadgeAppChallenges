using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01_Cafe
{
    public class CafeRepository
    {
        private List<CafeMenuItems> _listofmeals = new List<CafeMenuItems>();

        // Create

        public void AddMealsToMenu(CafeMenuItems meal)
        {
            _listofmeals.Add(meal);
        }

        //Read
        public List<CafeMenuItems> GetListAllMenuItems()
        {
            return _listofmeals;
        }

    

        //Update 
        public bool UpdateMenuItemsbyMealId(int originalMealID, CafeMenuItems newContent)
        {
            //Find Content

            CafeMenuItems oldContent = GetListAllMenuItemsByMenuID(originalMealID);
            if (oldContent != null)
            {
                oldContent.Name = newContent.Name;
                oldContent.MenuID = newContent.MenuID;
                oldContent.Description = newContent.Description;
                oldContent.Ingredients = newContent.Ingredients;
                oldContent.Price = newContent.Price;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete

        public bool RemoveMenuItemsFromList (int menuId)

        {
            CafeMenuItems meal = GetListAllMenuItemsByMenuID(menuId);

            if(meal.MenuID != menuId)
            {
                return false;
            }

            int initialCount = _listofmeals.Count;
            _listofmeals.Remove(meal);

            if (initialCount > _listofmeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public CafeMenuItems GetListAllMenuItemsByMenuID(int mealID)
        {
            foreach(CafeMenuItems meal in _listofmeals)
            {
                if(meal.MenuID == mealID)
                {
                    return meal;
                }
            }
            return null;
        }

    }
}
