using EtlDemoNetStandard.RecordFormats;
using FileHelpers;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System.Collections.Generic;

namespace EtlDemoNetStandard.Etl
{
    public class GetFileDataOperation : AbstractOperation
    {
        public GetFileDataOperation(string inputFilePath)
        {
            FilePath = inputFilePath;
        }

        public string FilePath { get; set; }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {

            var engine = new FileHelperAsyncEngine<CustomerInput>();

            using (engine.BeginReadFile(FilePath))
            {
                foreach (var record in engine)
                {
                    yield return Row.FromObject(record);
                }
            }

        }
    }
}
