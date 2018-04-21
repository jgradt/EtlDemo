using EtlDemoNetStandard.RecordFormats;
using FileHelpers;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System.Collections.Generic;
using System.IO;

namespace EtlDemoNetStandard.Etl
{
    public class FileErrorsOutputOperation : AbstractOperation
    {
        public FileErrorsOutputOperation(string rejectedRecordsFilePath, string errorsFilePath)
        {
            RejectedRecordsFilePath = rejectedRecordsFilePath;
            ErrorsFilePath = errorsFilePath;
        }

        public string RejectedRecordsFilePath { get; set; }
        public string ErrorsFilePath { get; set; }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            using (var engine = new FileHelperAsyncEngine<CustomerInput>())
            {
                engine.HeaderText = engine.GetFileHeader();

                using (StreamWriter errorsFile = new StreamWriter(ErrorsFilePath))
                using (engine.BeginWriteFile(RejectedRecordsFilePath))
                {
                    foreach (Row row in rows)
                    {
                        if (!row.IsValid())
                        {
                            // write rejected record
                            var record = row.ToObject<CustomerInput>();
                            engine.WriteNext(record);

                            // write validation errors
                            errorsFile.WriteLine($"Record Id: {record.Id}");
                            foreach(var err in row.GetErrors().Split('|'))
                            {
                                errorsFile.WriteLine($"  {err}");
                            }

                            continue;
                        }
                        else
                        {
                            yield return row;
                        }

                    }
                }
            }

        }

    }
}
