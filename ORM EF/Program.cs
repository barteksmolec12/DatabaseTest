using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_EF
{
	class Program
	{
		static void Main(string[] args)

		{
			// ---------- ORM EntityFramework -----------

			Console.WriteLine("ORM EntityFramework - test wydajności");
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			NorthwindEntities db = new NorthwindEntities();
			var orderDetailsList = db.Order_Details.ToList();
			stopwatch.Stop();

			Console.WriteLine("Czas pobierania danych: {0}", stopwatch.Elapsed);
			Console.ReadLine();
		}
	}
}
