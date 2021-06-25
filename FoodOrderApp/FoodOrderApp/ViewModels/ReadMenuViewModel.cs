using FoodOrderApp.Services;
using FoodOrderApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;

[assembly: Dependency(typeof(ReadMenuViewModel))]
namespace FoodOrderApp.ViewModels
{
    public class ReadMenuViewModel
    {
        public object data;
        public string nazwa;
        public string opis;
        public string cena;
        public string nazwa1;
        public string opis1;
        public string cena1;
        private int iter = 0;

        public void GetData(string conn = "Data Source= foodappserv.database.windows.net; Initial Catalog = FoodAppDB; User ID = foodappadmin; Password=Appadmin123;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {

                SqlCommand command = new SqlCommand("select * from Products", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        data = (reader.ToString());
                        ReadSingleRow((IDataRecord)reader);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
   
        }

        public void ReadSingleRow(IDataRecord record)
        {
            if (iter == 0)
            {
                Console.WriteLine(String.Format("{0}", record[0], record[1]));
                nazwa = String.Format("{0}", record[0]);
                opis = String.Format("{0}", record[1]);
                cena = String.Format("{0}", record[2]);
            }
            if (iter == 1)
            {
                Console.WriteLine(String.Format("{0}", record[0], record[1]));
                nazwa1 = String.Format("{0}", record[0]);
                opis1 = String.Format("{0}", record[1]);
                cena1 = String.Format("{0}", record[2]);
            }
            iter++;
        }
    }
}
