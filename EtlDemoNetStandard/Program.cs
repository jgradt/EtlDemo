using EtlDemoNetStandard.Etl;
using System;

namespace EtlDemoNetStandard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Lets create a Rhino-ETL ----");
            Console.WriteLine("--------------------------------");
            // Here is the actual work. 
            var etl = new MainEtlProcessor();
            etl.Execute();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("----Hit any Rhino to exit------");
            Console.ReadKey();
        }
    }
}
