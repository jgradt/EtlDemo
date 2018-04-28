using FileHelpers;
using System;

namespace EtlDemo.RecordFormats
{
    [DelimitedRecord("|")]
    public class CustomerOutputToFile
    {
        public string Id;

        [FieldQuoted]
        public string FirstName;

        [FieldQuoted]
        public string LastName;

        public string Ssn;

        [FieldConverter(ConverterKind.Date, "yyyy-MM-dd")]
        public DateTime? DateOfBirth;

        [FieldQuoted]
        public string Address;

        [FieldQuoted]
        public string City;

        [FieldQuoted]
        public string State;

        public string Zip;

        public string MobilePhoneAreaCode;

        public string MobilePhone;

        public string HomePhoneAreaCode;

        public string HomePhone;
    }
}
