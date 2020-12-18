using Greeting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Greeting_Tests
{
    [TestClass]
    public class GreetingTests
    {
        private GreetingRepository _repo;
        private Customer _customer;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new GreetingRepository();
            _customer = new Customer();
            _customer.CustomerID = 1;
            _customer.FirstName = "Jane";
            _customer.LastName = "Doe";
            _customer.Email = "JDoe@hotmail.com";
            _customer.LastInvoice = new DateTime(2019, 02, 13);

            _repo.AddNewCustomer(_customer);
        }

        //Add
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange
            Customer newCustomer = new Customer();
            newCustomer.CustomerID = 5;

            GreetingRepository repository = new GreetingRepository();

            //Act
            repository.AddNewCustomer(newCustomer);

            IGreeting contentfromList = repository.GetListofAllCustomersByCustomerID(5);

            //Assert
            Assert.IsNotNull(contentfromList);
        }

        //Update
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
            Customer newCustomer = new Customer();
            newCustomer = new Customer();
            newCustomer.CustomerID = 6;
            newCustomer.FirstName = "Jane";
            newCustomer.LastName = "Doe";
            newCustomer.Email = "JDoe@hotmail.com";
            newCustomer.LastInvoice = new DateTime(2019, 02, 13);

            //Act
            bool UpdateResult = _repo.UpdateCustomerByID(1, newCustomer);

            //Assert
            Assert.IsTrue(UpdateResult);

        }

        [DataTestMethod]
        [DataRow("Jane",true)]
        [DataRow("Daniele",true)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string OriginalFirstName, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            Customer newCustomer = new Customer();
            newCustomer = new Customer();
            newCustomer.CustomerID = 6;
            newCustomer.FirstName = "Jane";
            newCustomer.LastName = "Doe";
            newCustomer.Email = "JDoe@hotmail.com";
            newCustomer.LastInvoice = new DateTime(2019, 02, 13);

            //Act
            bool UpdateResult = _repo.UpdateCustomerByID(1, newCustomer);
            //Assert
            Assert.AreEqual(shouldUpdate, UpdateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _repo.RemoveCustomersFromList(1);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
