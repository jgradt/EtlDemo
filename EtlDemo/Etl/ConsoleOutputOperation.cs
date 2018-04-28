using EtlDemo.RecordFormats;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System;
using System.Collections.Generic;

namespace EtlDemo.Etl
{
    public class ConsoleOutputOperation : AbstractOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            foreach(Row row in rows)
            {
                Console.WriteLine($"Name: {row[nameof(CustomerOutputToFile.FirstName)]} {row[nameof(CustomerOutputToFile.LastName)]}");
                yield return row;
            }
        }
    }
}
