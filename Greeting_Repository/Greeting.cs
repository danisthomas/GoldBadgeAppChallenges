using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public enum CustomerType
    {
        Past = 1,
        Current,
        Potential

    }
    public interface IGreeting
    {
         string FirstName { get; set; }
         string LastName { get; set; }
         string Email { get; set; }
         int CustomerID { get; set; }
         DateTime LastInvoice { get; set; }
         string EmailType { get; set; }

        CustomerType TypeOfCustomer { get; set; }
        CustomerType GetTimeSpan(Customer customer);
    }
    public class Customer : IGreeting
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CustomerID { get; set; }
        public DateTime LastInvoice { get; set; }
        public string EmailType { get; set; }
        

        public CustomerType TypeOfCustomer { get; set; }
        public CustomerType GetTimeSpan(Customer customer)
        {
            TimeSpan dateDiff = DateTime.Now - customer.LastInvoice;
            if(dateDiff.Days >= 365 && dateDiff.Days < 730)
            {
                customer.TypeOfCustomer= CustomerType.Past;
            }
            if(dateDiff.Days < 365)
            {
                customer.TypeOfCustomer = CustomerType.Current;

            }
            if(dateDiff.Days >= 730)
            {
                customer.TypeOfCustomer = CustomerType.Potential;
            }
            return customer.TypeOfCustomer;
        }
      
    }
    


}
