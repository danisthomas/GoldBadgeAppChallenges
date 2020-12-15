using CompanyOutings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CompanyOutings_Tests
{
    [TestClass]
    public class CompanyOutingsTests
    {
        Golf golf = new Golf();
        Bowling bowl = new Bowling();
        AmusementPark amuse = new AmusementPark();
        Concert concert = new Concert();

        private CompanyOutingsRepository _repo;
       
        [TestInitialize]
        public void TestMethod1()
        {
            Golf golf = new Golf();
            Bowling bowl = new Bowling();
            AmusementPark amuse = new AmusementPark();
            Concert concert = new Concert();
            _repo = new CompanyOutingsRepository();

            golf.CostPerPerson = 60;
            golf.DateOfOuting = new DateTime(2019, 03, 23);
            golf.NumberOfPeople = 300;
            golf.TypeOfOuting = OutingType.Golf;
            golf.CostPerEvent();
            bowl.CostPerPerson = 20;
            bowl.DateOfOuting = new DateTime(2019, 4, 20);
            bowl.NumberOfPeople = 100;
            bowl.TypeOfOuting = OutingType.Bowling;
            bowl.CostPerEvent();
            amuse.CostPerPerson = 200;
            amuse.NumberOfPeople = 250;
            amuse.DateOfOuting = new DateTime(2019, 05, 22);
            amuse.TypeOfOuting = OutingType.AmusePark;
            amuse.CostPerEvent();
            concert.CostPerPerson = 90;
            concert.NumberOfPeople = 150;
            concert.DateOfOuting = new DateTime(2019, 06, 02);
            concert.TypeOfOuting = OutingType.Concert;
            concert.CostPerEvent();

            _repo._listOfOutings.Add(golf);
            _repo._listOfOutings.Add(bowl);
            _repo._listOfOutings.Add(amuse);
            _repo._listOfOutings.Add(concert);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {

            //Arrange
            //TestInitialize
            golf.CostPerPerson = 100;
            golf.DateOfOuting = new DateTime(2019, 05, 23);
            golf.NumberOfPeople = 100;
            golf.TypeOfOuting = OutingType.Golf;
            golf.CostPerEvent();

            //Act

            _repo._listOfOutings.Add(golf);

            List<IOutings> contentFromList = _repo.GetListOfOutings();

            //Assert
            Assert.IsNotNull(contentFromList);

        }

        
    }
}
