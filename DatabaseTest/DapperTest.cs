using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
	class DapperTest
	{
		public void TestConnection()
		{
            Console.WriteLine("DAPPER - test wydajności");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            IDbConnection db = new SqlConnection(connectionString);

            var resultFromDb = db.Query<OrderDetails>("Select * From [Order Details]").ToList();

            stopwatch.Stop();
            Console.WriteLine("Czas pobierania danych: {0}", stopwatch.Elapsed);
            Console.ReadLine();

            Console.ReadLine();
        }
	}
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }
}
