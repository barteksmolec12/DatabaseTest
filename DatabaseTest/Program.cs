using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //--- ADO.NET - czyste ---
            AdoNetTest a = new AdoNetTest();
            a.TestConnection();

            //---Dapepr .NET --------
            DapperTest t = new DapperTest();
            t.TestConnection();

        }    

    }
    
}
