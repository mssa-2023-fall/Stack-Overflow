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

        public Customer FindCustomerByNameAndPassword(Dictionary<string, Customer> Customers, string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool LoginSucessfull(Customer customer, string password)
        {
            throw new NotImplementedException();
        }
    }
}
