using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public class GreetingRepository
    {
        Customer customer = new Customer();
        List<IGreeting> listOfCustomers = new List<IGreeting>();
        List<IGreeting> listOfPastCustomers = new List<IGreeting>();
        List<IGreeting> listOfCurrentCustomers = new List<IGreeting>();
        List<IGreeting> listOfPotentialCustomers = new List<IGreeting>();

        //Create

        public void AddNewCustomer(Customer customer)
        {
            listOfCustomers.Add(customer);
        }

        public void AddCustomerToCorrectList()
        {
            foreach (IGreeting customer in listOfCustomers)
            {
                if (customer.TypeOfCustomer == CustomerType.Current)
                {
                    listOfCurrentCustomers.Add(customer);
                }
                if (customer.TypeOfCustomer == CustomerType.Past)
                {
                    listOfPastCustomers.Add(customer);

                }
                if (customer.TypeOfCustomer == CustomerType.Potential)
                {
                    listOfPotentialCustomers.Add(customer);
                }
            }
        }

        //Read
        public List<IGreeting> GetListOfAllCustomers()
        {
            return listOfCustomers;
        }

        public List<IGreeting> GetListOfPotentialCustomers()
        {
            return listOfPotentialCustomers;
        }

        public List<IGreeting> GetListOfCurrentCustomers()
        {
            return listOfCurrentCustomers;
        }
        public List<IGreeting> GetListOfPastCustomers()
        {
            return listOfPastCustomers;
        }

        //Update

        public bool UpdateCustomerByID(int originalCustomerID, Customer newContent)
        {
            //Find Content

            IGreeting oldContent = GetListofAllCustomersByCustomerID(originalCustomerID);
            if (oldContent != null)
            {
                oldContent.FirstName = newContent.FirstName;
                oldContent.LastName = newContent.LastName;
                oldContent.Email = newContent.Email;
                oldContent.LastInvoice = newContent.LastInvoice;
                
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete

        public bool RemoveCustomersFromList(int customerId)

        {
            IGreeting customer = GetListofAllCustomersByCustomerID(customerId);

            if (customer.CustomerID != customerId)
            {
                return false;
            }

            int initialCount = listOfCustomers.Count;
            listOfCustomers.Remove(customer);

            if (initialCount > listOfCustomers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper
        public IGreeting GetListofAllCustomersByCustomerID(int customerID)
        {
            foreach (IGreeting customer in listOfCustomers)
            {
                if (customer.CustomerID == customerID)
                {
                    return customer;
                }
            }
            return null;
        }

        public IGreeting AssignEmailType()
        {
            foreach (IGreeting customer in listOfCustomers)
            {
                if (customer.TypeOfCustomer == CustomerType.Current)
                {
                    customer.EmailType = ("Thank you for your work with us. We appreciate your loyalty. Here's a coupon!");
                }
                if (customer.TypeOfCustomer == CustomerType.Past)
                {
                    customer.EmailType = ("It's been a long time since we've heard from you!");
                }
                if (customer.TypeOfCustomer == CustomerType.Potential)
                {
                    customer.EmailType = ("We currently have the lowest rates on Helicopter Insurance!");
                }
               
            }
            return null;

        }
    }
}
