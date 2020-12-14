using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01_Cafe
{
    public class CafeMenuItems
    {
        public string Name { get; set; }
        public int MenuID { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public CafeMenuItems () { }

        public CafeMenuItems ( string name, int menuNumber, string description, string ingredients, double price)
        {
            MenuID = menuNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
