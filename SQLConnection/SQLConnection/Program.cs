using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

string ConnectionString = @"Server=mssa23.database.windows.net; Authentication=Active Directory Password; Encrypt=True; Database=WideWorldImportersDW-Standard; User Id=student8@mssa2023outlook.onmicrosoft.com; Password=Pa55w.rd1234";

//Lists
List<EmployeeDTO> empList = CreateListOfEmployee(ConnectionString);

List<EmployeeDTO> CreateListOfEmployee(string connectionString)
{
    List<EmployeeDTO> empList = new List<EmployeeDTO>();
    string sql = @"SELECT [Employee Key]
      ,[WWI Employee ID]
      ,[Employee]
      ,[Preferred Name]
      ,[Is Salesperson]
      ,[Photo]
      ,[Valid From]
      ,[Valid To]
      ,[Lineage Key]
      FROM [Dimension].[Employee]";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        empList = conn.Query<EmployeeDTO>(sql).ToList(); // added this
    }
    return empList;
}

Console.WriteLine($"we have {empList.Count} employees"); //returns 213


ReadACustomer(ConnectionString);


static void ReadACustomer(string ConnectionString) 
{
// First Tests
Console.WriteLine("Please write a 5 digit postal code: ");
string postalCode = Console.ReadLine();

    using (var conn = new SqlConnection(ConnectionString))
    {
        conn.Open();
        string sql = "SELECT * FROM Dimension.Customer where [postal code] = @potalcode";

        //Create an instance of SqlCommand Objs
        var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@potalcode", postalCode));


        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.GetValue(0));
            Console.WriteLine(reader.GetValue(1));
            Console.WriteLine("-------------------------");
        }

        conn.Close();
    }
}


//Victor's method:
/*
static void ReadACustomer(string ConnectionString)
{
    Console.WriteLine("Please enter a postal code like 90005, 5 digits, followed by enter");
    string postalCode = Console.ReadLine();

    //quick check to confirm database access is possible
    using (var conn = new SqlConnection(ConnectionString))
    {
        conn.Open();
        string sql = "select [Customer Key], Customer, [Valid From] from Dimension.Customer where [postal code] = @postalcode";//@postalcode declares a parameter
                                                                                                                               //create an instance of SqlCommand Object, constructor of SqlCommand accepts sql and connection object-conn
        var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@postalcode", postalCode));

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int custKey = reader.GetInt32(0);
            string custName = reader.GetString(1);
            DateTime custValidFrom = reader.GetDateTime(2);

            Console.WriteLine($"{custName} has id:{custKey}. Active since {custValidFrom}");
            //for (int i = 0; i < reader.FieldCount; i++) {
            //    Console.Write(reader.GetName(i) + ":");
            //    Console.Write(reader.GetValue(i) + "\t");
            //}

            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
        }

        conn.Close();
    }
}
*/
