using EtlDemoNetStandard.Etl;
using System;

namespace EtlDemoNetStandard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Etl Demo----");
            Console.WriteLine("--------------------------------");

            // Here is the actual work. 
            Console.WriteLine("  Processing... ");
            var etl = new MainEtlProcessor();
            etl.Execute();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("----Hit any key to exit------");
            Console.ReadKey();
        }
    }
}
