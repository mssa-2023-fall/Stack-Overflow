using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class RestaurantMenu
    {
        //public string protein { get; set; }

        public string MealForProtein(string protein)
        {
            var result =
                protein.ToLower() == "beef" ? "hamburger" :
                protein.ToLower() == "pepperoni" ? "pepperoni pizza" :
                protein.ToLower() == "tofu" ? "tofu fried rice" :
                "Sorry we do not serve that protein.";
            return result;
        }
    }
   
    /*internal class Restaurant
    {
        public static void Waiter ()
        {
            Welcome();
        }
        public static string Welcome()
        {
            Console.WriteLine("Welcome to Leo's Food n' Go\n We have a limited selection of meals, \nthose meals can either have a protein of beef, pepperoni, or tofu.\nWhat can I interest you in?");
            string response = "";
            try
            {
                response = Console.ReadLine();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return reponse;
        }
    }*/
    // Step 1 - Create a test that turns all responses into a lower case string so that it can be compared
    // waiter begins program by stating menu, and waits for the response
    // response is also turned into a string that is then ToLower() so that it can be compared

    // Step 2 - create a switch case statement for beef | pepperoni | tofu | default
    // I am going to challenge myself to try the short hand with the default short hand of a switch statement being _ 
    // return a string of the response associated with the desired protein

    // Step 3 - Create a test method to ensure desire response is given for each kind of protein
    // Checks to see all responses are type of string for waiter (try null, string, and an int) (3 cases)
    // Checks that the responses are correct with the desired protein (4 cases)

}
