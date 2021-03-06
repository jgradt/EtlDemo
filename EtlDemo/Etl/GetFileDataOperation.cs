﻿using EtlDemo.RecordFormats;
using FileHelpers;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System.Collections.Generic;
using System.IO;

namespace EtlDemo.Etl
{
    public class GetFileDataOperation : AbstractOperation
    {
        public GetFileDataOperation(string inputFilePath)
        {
            FilePath = inputFilePath;

            OnFinishedProcessing += Operation_OnFinishedProcessing;
        }

        private int recordCount = 0;

        public string FilePath { get; set; }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {

            var engine = new FileHelperAsyncEngine<CustomerInput>();
            //engine.ErrorMode = ErrorMode.SaveAndContinue;

            // TODO: add error handling in case file path does not exist
            using (engine.BeginReadFile(FilePath))
            {
                foreach (var record in engine)
                {
                    recordCount++;
                    yield return Row.FromObject(record);
                }
            }
        }

        private void Operation_OnFinishedProcessing(IOperation op)
        {
            Info("Processed Input File: '{0}'", Path.GetFullPath(FilePath));
            Info("Input File record count: {0}", recordCount);
        }

    }
}
