using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSecurityLab
{
    public interface LoginInterface
    {
        //Creating Customers
        void IntitalizeThreeCustomers();
        

        //Finding
        Customer FindCustomerByNameAndPassword(Dictionary<string, Customer> Customers, string name, string password);

        bool LoginSucessfull(Customer customer, string password);
    }
}
