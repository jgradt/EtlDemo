using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System.IO;

namespace EtlDemoNetStandard.Etl
{

    public class MainEtlProcessor : EtlProcess
    {
        protected override void Initialize()
        {
            var inputFilePath = Path.Combine(Globals.InputFileDirectory, "customers_1000_rows.csv");
            var rejectedRecordsFilePath = Path.Combine(Globals.OutputFileDirectory, "rejected_output.txt");
            var errorsFilePath = Path.Combine(Globals.OutputFileDirectory, "errors_output.txt");
            var outputFilePath = Path.Combine(Globals.OutputFileDirectory, "test_output.txt");

            Register(new GetFileDataOperation(inputFilePath));
            Register(new RecordValidationOperation());
            Register(new FileErrorsOutputOperation(rejectedRecordsFilePath, errorsFilePath));
            Register(new TransformDataOperation());
            Register(new ConsoleOutputOperation());
            Register(new FileOutputOperation(outputFilePath));

            Info("########################");
            Info("Initializing ETL Process");
        }

        protected override void OnFinishedProcessing(IOperation op)
        {
            Info("{0} Duration: {1}", op.Name, op.Statistics.Duration);
        }

        protected override void PostProcessing()
        {
            base.PostProcessing();
            Info("ETL Process Complete");
        }
    }
}
