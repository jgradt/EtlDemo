using FileHelpers;
using System;

namespace EtlDemoNetStandard.RecordFormats
{
    [DelimitedRecord("|")]
    public class CustomerOutputToFile
    {
        public int Id;

        [FieldQuoted]
        public string FirstName;

        [FieldQuoted]
        public string LastName;

        [FieldQuoted]
        public string Ssn;

        [FieldQuoted]
        [FieldConverter(ConverterKind.Date, "yyyy-MM-dd")]
        public DateTime? DateOfBirth;

        [FieldQuoted]
        public string Address;

        [FieldQuoted]
        public string City;

        [FieldQuoted]
        public string State;

        //[FieldQuoted]
        public string Zip;

        //[FieldQuoted]
        public string MobilePhoneAreaCode;

        //[FieldQuoted]
        public string MobilePhone;

        //[FieldQuoted]
        public string HomePhoneAreaCode;

        //
        [FieldQuoted]
        public string HomePhone;
    }
}
