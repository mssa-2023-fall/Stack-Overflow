using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System;
using RandomNameGeneratorLibrary;



/** TODO:   Notes
-- Present menu
-- 1 Creates a customer table - customerId identity
-- 2 Generate 100 Unique Custoemer
-- 3 Display ALL custoemrs - make it look good?
-- 4 Delete a customer -> Which ID?
-- 5 Display Count of Customers        Bonus: Age calculated outside of DB */

int run = 1;
while(run != 6)
{
    run = seeMenu();
    ProcessInput(run);
}




//Menu
void ProcessInput(int num)
{
    switch ( num )
    {
        case 1:
            Reset();
            break;
        case 2:
            GenerateRandoms();
            break;
        case 3:
            seeAllCustomers();
            break;
        case 4:
            ConfirmCustomer();
            break;
        case 5:
            Count();
            break;
        case 6:
            Console.WriteLine("Goodbye!");
            break;
    }
}

int seeMenu()
{
    Console.WriteLine("\nWelcome to Leo's customer database, here is our menu:\n1 - Reset our customer table\n2 - Generate 100 unique Customers\n3 - Display All Customers\n4 - Delete a certain customer\n5 - Display how many customers we have\n6 - Quit program");
    int result;
    try
    {
        result = Int32.Parse(Console.ReadLine());
    } catch (Exception e)
    {
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\ninvalid input... try again\n");
        return seeMenu();
    }
    if (result >= 1 && result <= 6) return result;
    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nInvalid input... try again\n");
    return seeMenu();
}

//Refresh the table Method 1
void Reset()
{
    List<CustomerDTO> customers = CreateListOfCustomers(ConnectionString);
    foreach(CustomerDTO c in customers) DeleteCustomer(c.CustomerID);
    Console.WriteLine("Reset sucessful.");
}

//Generate Name/BirthDate Method 2
void GenerateRandoms()
{
    var personGenerator = new PersonNameGenerator();
    Random r = new Random();

    string sql = @"INSERT INTO [lk].[customers] (CustomerName, DateOfBirth) VALUES (@Name, @Dob);";

    using(var con = new SqlConnection(ConnectionString))
    {
        for (int i = 0; i < 100; i++)
        {
            string name = personGenerator.GenerateRandomFirstAndLastName();
            int randomYear = r.Next(1900, 2004);
            int randomMonth = r.Next(1, 13);
            int randomDay = r.Next(1, 29);

            DateTime birthdate = new DateTime(randomYear, randomMonth, randomDay);

            object[] param = { new { Name = name, Dob = birthdate } };

            con.Execute(sql, param);
        }
    }
}


//Select Method for # 3 & 5
void Count()
{
    Console.WriteLine("Counting...");
    List<CustomerDTO> customers = CreateListOfCustomers(ConnectionString);
    Console.WriteLine($"There are {customers.Count} customers in the database.");
}
void seeAllCustomers()
{
    List<CustomerDTO> customers = CreateListOfCustomers(ConnectionString);
    Console.WriteLine(" ID |        Customer Name |     Date Of Birth | Age");
    foreach (CustomerDTO a in customers) Console.WriteLine(value: $"{a.CustomerID} | {a.CustomerName, 20} | {a.DateOfBirth.ToString("MM/dd/yyyy"), 17} | {a.Age()}");
}
List<CustomerDTO> CreateListOfCustomers(string connectionString)
{
    List<CustomerDTO> customers = new List<CustomerDTO>();
    string sql = @"SELECT [CustomerName]
      ,[DateOfBirth]
      ,[CustomerID]
      FROM [lk].[customers]";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        customers = conn.Query<CustomerDTO>(sql).ToList(); 
    }
    return customers;
}

//Delete an individual;
void ConfirmCustomer()
{
    Console.WriteLine("Please write an ID: ");
    string custID = Console.ReadLine();

    using (var conn = new SqlConnection(ConnectionString))
    {
        conn.Open();
        string sql = "SELECT * FROM lk.customers where [CustomerID] = @custID";

        var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@custID", custID));


        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("Name : " + reader.GetValue(0));
            Console.WriteLine("DOB : " + reader.GetValue(1));
            Console.WriteLine("ID : " + reader.GetValue(2));

        }

        Console.WriteLine("Please confrim [Y]/[n]");
        if (Console.ReadLine() == "Y")
        {
            Console.WriteLine("deleting");
            try
            {
                DeleteCustomer(Int32.Parse(custID));

                Console.WriteLine("Delete completed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else Console.WriteLine("not deleting...");

        conn.Close();
    }
}
void DeleteCustomer(int id)
{
    string sql = @"DELETE FROM lk.customers WHERE CustomerID = @id";
    using (var con = new SqlConnection(ConnectionString))
    {
        object[] param = { new { id = id } };
        con.Execute(sql, param);
    }
}