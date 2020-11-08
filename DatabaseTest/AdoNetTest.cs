using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseTest
{
	public class AdoNetTest
	{
		public void TestConnection()
		{
            Console.WriteLine("ADO.NET - test wydajności");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
			
            string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "select* from [Order Details];",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("Znaleziono wszytskie wiersze");
                }
                else
                {
                    Console.WriteLine("Brak wierszy");
                }
                reader.Close();

            }

            stopwatch.Stop();
            Console.WriteLine("Czas pobierania danych: {0}", stopwatch.Elapsed);
            Console.ReadLine();
        }
    }
}

