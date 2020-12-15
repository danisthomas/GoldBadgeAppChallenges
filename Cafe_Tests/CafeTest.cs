using Challenge_01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cafe_Tests
{
    [TestClass]
    public class CafeTest
    {
        private CafeRepository _menu;
        private CafeMenuItems _meal;

        [TestInitialize]
        public void Arrange()
        {
            _menu = new CafeRepository();

            _meal = new CafeMenuItems("Pizza", 1, "Wonderful round goodness!", "Wheat Dough, Tomato Sauce, Cheese, Italian Spices", 8.99);
            _menu.AddMealsToMenu(_meal);
            
        }

        //Add
        [TestMethod]
        public void AddToList_ShouldGetNull()
        {
            //Arrange
            CafeMenuItems content = new CafeMenuItems();
            content.MenuID = (1);
            CafeRepository repository = new CafeRepository();

            //Act

            repository.AddMealsToMenu(content);
            CafeMenuItems contentFromDirectory = repository.GetListAllMenuItemsByMenuID(1);

            //Assert
            Assert.IsNotNull(contentFromDirectory);

        }

        //Update
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange-Test Initialize
            CafeMenuItems newContent = new CafeMenuItems("PB&J", 4, "Childhood Favorite", "Bread, Peanutbutter, Jelly", 3.99);

            //Act
            bool updateResult = _menu.UpdateMenuItemsbyMealId(1, newContent);

            //Assert
            Assert.IsTrue(updateResult);

        }

        //Delete 
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrang-Testinitialize

            //Act
            bool deleteResult = _menu.RemoveMenuItemsFromList(_meal.MenuID);


            //Assert
            Assert.IsTrue(deleteResult);
        }

        [DataTestMethod]
        [DataRow("Pizza", true)]
        [DataRow("Gyro",false)]
        public void UpdateExistingContent_ShouldMatchGivenBool()
        {
            
            //Arrange-Test Initialize
            CafeMenuItems newContent = new CafeMenuItems("PB&J", 4, "Childhood Favorite", "Bread, Peanutbutter, Jelly", 3.99);

            //Act
            bool updateResult = _menu.UpdateMenuItemsbyMealId(1, newContent);

            //Assert
            Assert.IsTrue(updateResult);

        }
    }

}
