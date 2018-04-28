using EtlDemoNetStandard.RecordFormats;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System.Collections.Generic;
using System.Linq;

namespace EtlDemoNetStandard.Etl
{
    public class RecordValidationOperation : AbstractOperation
    {
        public RecordValidationOperation()
        {
        }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            foreach (Row row in rows)
            {
                var record = row.ToObject<CustomerInput>();

                // TODO: lookup validator based on record type
                var validator = new CustomerValidator();
                var validationResult = validator.Validate(record);
                row.SetValid(validationResult.IsValid);
                if (!validationResult.IsValid)
                {
                    row.SetErrors(string.Join("|", validationResult.Errors.Select(error => error.ErrorMessage)));
                }

                yield return row;
            }
        }

    }
}
