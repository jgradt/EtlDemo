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

            OnFinishedProcessing += Operation_OnFinishedProcessing;
        }

        private int errorCount = 0;
        private int validRecordCount = 0;

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
                            errorCount++;

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
                            validRecordCount++;
                            yield return row;
                        }

                    }
                }
            }

        }

        private void Operation_OnFinishedProcessing(IOperation op)
        {
            Info("Row count with errors: {1}", op.Name, errorCount);
            Info("Row count with valid records: {1}", op.Name, validRecordCount);
            Info("Rejected Records File: '{0}'", Path.GetFullPath(RejectedRecordsFilePath));
            Info("Errors File: '{0}'", Path.GetFullPath(ErrorsFilePath));
        }
    }
}
