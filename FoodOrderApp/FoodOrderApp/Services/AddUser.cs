using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FoodOrderApp.ViewModels
{
    public class AddUser
    {
        public async System.Threading.Tasks.Task InsertDataAsync(string conn = "Data Source= foodappserv.database.windows.net; Initial Catalog = FoodAppDB; User ID = foodappadmin; Password=Appadmin123;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {


                SqlCommand command = new SqlCommand("Insert INTO Users (email, passwd) VALUES ('test', 'test')", connection);
                try
                {
                    connection.Open();
                    int rowCount = await command.ExecuteNonQueryAsync();
                    Console.WriteLine(String.Format("Number of rows inserted={0}", rowCount));
                }
                catch
                {
                    //
                }

        }
        }
    }
}
