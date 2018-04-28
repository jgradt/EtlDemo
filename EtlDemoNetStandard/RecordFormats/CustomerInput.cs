using EtlDemoNetStandard.FieldConverters;
using FileHelpers;
using System;
using FluentValidation;

namespace EtlDemoNetStandard.RecordFormats
{
    [DelimitedRecord(","), IgnoreFirst(1)]
    public class CustomerInput
    {
        public string Id;

        public string FirstName;

        public string LastName;

        public string Ssn;

        public string DateOfBirth;

        public string Address;

        public string City;

        public string State;

        public string Zip;

        //[FieldConverter(typeof(PhoneConverter))]
        public string MobilePhone;

        //[FieldConverter(typeof(PhoneConverter))]
        public string HomePhone;

        public string Email;

    }

    public class CustomerValidator : AbstractValidator<CustomerInput>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty().Must(val => int.TryParse(val, out int r)).WithMessage("Id is invalid");
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(customer => customer.Ssn).NotEmpty().WithMessage("SSN is required");
            RuleFor(customer => customer.Ssn).Matches(@"^\d{3}-\d{2}-\d{4}$").WithMessage("SSN is invalid");
            RuleFor(customer => customer.DateOfBirth).NotEmpty().WithMessage("Date of birth is required");
            RuleFor(customer => customer.DateOfBirth).Must(val => DateTime.TryParse(val, out DateTime r)).WithMessage("Date of birth is not a valid date");
            RuleFor(customer => customer.State).NotEmpty().WithMessage("State is required");
            RuleFor(customer => customer.Zip).NotEmpty().WithMessage("Zip code is required");
            RuleFor(customer => customer.Zip).Matches(@"^\d{5}$").WithMessage("Zip code must be 5 digits");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Email address is invalid");

            RuleFor(customer => customer).Must(customer => !string.IsNullOrWhiteSpace(customer.HomePhone) || !string.IsNullOrWhiteSpace(customer.MobilePhone))
                .WithMessage("At least one phone number is required");
             
        }

    }
}
