using EtlDemoNetStandard.RecordFormats;
using FileHelpers;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System.Collections.Generic;

namespace EtlDemoNetStandard.Etl
{
    public class FileOutputOperation : AbstractOperation
    {
        public string FilePath { get; set; }

        public FileOutputOperation(string outputFilePath)
        {
            FilePath = outputFilePath;
        }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            var engine = new FileHelperAsyncEngine<CustomerOutputToFile>();
            engine.HeaderText = engine.GetFileHeader();

            using (engine.BeginWriteFile(FilePath))
            {
                foreach (Row row in rows)
                {
                    var record = row.ToObject<CustomerOutputToFile>();

                    engine.WriteNext(record);

                    yield return row;
                }
            }

        }

    }
}
