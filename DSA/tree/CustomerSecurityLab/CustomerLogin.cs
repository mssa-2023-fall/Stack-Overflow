using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSecurityLab
{
    public class CustomerLogin : LoginInterface
    {
        public Dictionary<string, Customer> Customers = new Dictionary<string, Customer>();
        public void IntitalizeThreeCustomers()
        {
            Customers.Add("Johnny", new Customer("John Smith", "smith.john@gmail.com", "1234-3421-1234-4321", "password"));
            Customers.Add("Danny", new Customer("Dan Smith", "smith.Dan@gmail.com", "1234-3421-1234-4321", "password"));
            Customers.Add("Jackie", new Customer("Jacki Smith", "smith.jacki@gmail.com", "1234-3421-1234-4321", "password"));
        }

        public Customer FindCustomerByNameAndPassword(string name, string password)
        {
            foreach(Customer customer in Customers.Values)
            {
                if (customer.Name == name && customer.VerifyPassword(password) )
                {
                    return customer;
                }
            }
            throw new Exception("Cannot find user");
        }

        public bool LoginSucessfull(Customer customer, string password)
        {
            return customer.VerifyPassword(password);
        }
    }
}
