using EtlDemoNetStandard.FieldConverters;
using FileHelpers;
using System;

namespace EtlDemo.RecordFormats
{
    [DelimitedRecord(","), IgnoreFirst(1)]
    public class CustomerInput
    {
        public int Id;

        public string FirstName;

        public string LastName;

        public string Ssn;

        [FieldConverter(ConverterKind.Date, "M/d/yyyy")]
        public DateTime? DateOfBirth;

        public string Address;

        public string City;

        public string State;

        public string Zip;

        [FieldConverter(typeof(PhoneConverter))]
        public string MobilePhone;

        [FieldQuoted]
        [FieldConverter(typeof(PhoneConverter))]
        public string HomePhone;

        public string Email;

    }
}
