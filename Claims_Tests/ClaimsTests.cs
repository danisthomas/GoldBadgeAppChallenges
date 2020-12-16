using Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Claims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        private ClaimsRepository _repo;
        
        private Claims _claim;
       
        [TestInitialize]
        public void Arrange()
        {
            DateTime oneIncident = new DateTime(2020, 2, 22);
            DateTime oneClaim = new DateTime(2020, 3, 5);

            _repo = new ClaimsRepository();
            _claim = new Claims(1,ClaimType.Car,"Breakin",500,oneIncident,oneClaim,true);

            _repo.AddClaimsToList(_claim);
        }
        //Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Claims newClaim = new Claims();
            ClaimsRepository repository = new ClaimsRepository();

            //Arrange-Test initialize
            newClaim.Description="Breakin";

            //Act
            repository.AddClaimsToList(newClaim);

            List<Claims> contentFromDirectory = repository.GetListOfClaims();
            //Assert
            Assert.IsNotNull(contentFromDirectory);
        }

    }
}
