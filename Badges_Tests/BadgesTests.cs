using Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badges_Tests
{
    [TestClass]
    public class BadgesTests
    {
        private BadgesRepository _repo;
        private Badges _content;
        private Dictionary<int, Badges> _dict;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepository();
            _content = new Badges(1234, new List<string> { "A4", "B5", "C3" }, "John Doe");
            _repo.CreateNewBadge(_content);
           
        }

        //Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange- TestInitialize
            Badges  content = new Badges();
            content.BadgeID = 5555;
            BadgesRepository repository = new BadgesRepository();

            //Act
            repository.CreateNewBadge(content);
            

            Badges contentFromDirectory = repository.GetBadgeByBadgeID(5555);
            Dictionary<int, Badges> contentFromDictionary = repository.GetDictOfBadges();

            //Assert
            Assert.IsNotNull(contentFromDirectory);
            Assert.IsNotNull(contentFromDictionary);

        }
       
        //Delete

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange- Test Initialize
            Badges content = new Badges(1234, new List<string> { "A4", "B5", "C3" }, "John Doe");
            Badges deleteConent = _repo.GetBadgeByBadgeID(_content.BadgeID);
            int badgeID = content.BadgeID;

            //Act
            bool deleteResult = _repo.DeleteDoorsOfCurrentListOfBadges( content.BadgeID);

            //Assert
            Assert.IsTrue(deleteResult);
        }

    }
}
