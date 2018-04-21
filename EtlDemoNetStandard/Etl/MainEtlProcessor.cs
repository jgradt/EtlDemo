using Rhino.Etl.Core;
using System.IO;

namespace EtlDemoNetStandard.Etl
{

    public class MainEtlProcessor : EtlProcess
    {
        protected override void Initialize()
        {
            Register(new GetFileDataOperation(Path.Combine(Globals.InputFileDirectory, "customers_1000_rows.csv")));
            Register(new RecordValidationOperation());
            Register(new FileErrorsOutputOperation(Path.Combine(Globals.OutputFileDirectory, "rejected_output.txt"),
                Path.Combine(Globals.OutputFileDirectory, "errors_output.txt")));
            Register(new TransformDataOperation());
            Register(new ConsoleOutputOperation());
            Register(new FileOutputOperation(Path.Combine(Globals.OutputFileDirectory, "test_output.txt")));
        }
    }
}
