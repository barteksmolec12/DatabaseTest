
using CompiledQueryEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Diagnostics;
using System.Linq;

namespace CompiledQueryEF
{
	class Program
	{
		static void Main(string[] args)

		{
			ExecuteRawSqlQueriesTest();
			//CompiledQueryTest(); //test Compiled Query Entity Framework

		}
		public static void CompiledQueryTest()
		{
			Console.WriteLine("Compiled Query EF- test wydajności");
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();


			var query = EF.CompileQuery((NorthwindContext db, int id)
							  => (from s in db.OrderDetails
								  where s.ProductId > id
								  select s));
			using (NorthwindContext ctx = new NorthwindContext())
			{
				var listOrderDetails = query.Invoke(ctx, 0);
				


			};

			stopwatch.Stop();

			Console.WriteLine("Czas pobierania danych: {0}", stopwatch.Elapsed);
			Console.ReadLine();

		}
		public static void ExecuteRawSqlQueriesTest()
		{
			using(NorthwindContext db= new NorthwindContext())
			{

				Console.WriteLine("Execute Raw SQL Queries- test wydajności");
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
					
					var result = db.OrderDetails.FromSqlRaw("Select * from [Order Details]").ToList();
				
				stopwatch.Stop();
				Console.WriteLine("Czas pobierania danych: {0}", stopwatch.Elapsed);
				Console.ReadLine();

			}

		}
		
	}
}
