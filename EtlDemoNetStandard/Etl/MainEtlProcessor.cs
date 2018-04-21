using Rhino.Etl.Core;
using System.IO;

namespace EtlDemoNetStandard.Etl
{

    public class MainEtlProcessor : EtlProcess
    {
        protected override void Initialize()
        {
            Register(new GetFileDataOperation(Path.Combine(Globals.InputFileDirectory, "customers_1000_rows.csv")));
            Register(new TransformDataOperation());
            Register(new ConsoleOutputOperation());
            Register(new FileOutputOperation(Path.Combine(Globals.OutputFileDirectory, "test_output.txt")));
        }
    }
}
