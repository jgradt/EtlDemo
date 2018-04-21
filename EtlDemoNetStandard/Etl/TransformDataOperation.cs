using EtlDemo.RecordFormats;
using EtlDemoNetStandard.RecordFormats;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EtlDemoNetStandard.Etl
{
    public class TransformDataOperation : AbstractOperation
    {
        string phonePattern = @"(?<areaCode>\d{3})(?<phone>\d{7})";
        static Dictionary<string, string> states;

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            foreach(Row row in rows)
            {
                var newRow = row.Clone();

                var mobilePhone = (string)newRow[nameof(CustomerInput.MobilePhone)];
                var homePhone = (string)newRow[nameof(CustomerInput.HomePhone)];

                // mobile phone
                var match = Regex.Match(mobilePhone ?? "", phonePattern);
                if(match.Success)
                {
                    newRow[nameof(CustomerOutputToFile.MobilePhoneAreaCode)] = match.Groups["areaCode"].Value;
                    newRow[nameof(CustomerOutputToFile.MobilePhone)] = match.Groups["phone"].Value;
                }
                else
                {
                    newRow[nameof(CustomerOutputToFile.MobilePhoneAreaCode)] = null;
                    newRow[nameof(CustomerOutputToFile.MobilePhone)] = null;
                }

                // home phone
                match = Regex.Match(homePhone ?? "", phonePattern);
                if (match.Success)
                {
                    newRow[nameof(CustomerOutputToFile.HomePhoneAreaCode)] = match.Groups["areaCode"].Value;
                    newRow[nameof(CustomerOutputToFile.HomePhone)] = match.Groups["phone"].Value;
                }
                else
                {
                    newRow[nameof(CustomerOutputToFile.HomePhoneAreaCode)] = null;
                    newRow[nameof(CustomerOutputToFile.HomePhone)] = null;
                }

                // state
                var state = (string)newRow[nameof(CustomerInput.State)];
                newRow[nameof(CustomerOutputToFile.State)] = GetStateFullName(state);

                yield return newRow;
            }
        }

        private string GetStateFullName(string abbreviation)
        {
            if(states == null)
            {
                states = new Dictionary<string, string>();

                states.Add("AL", "Alabama");
                states.Add("AK", "Alaska");
                states.Add("AZ", "Arizona");
                states.Add("AR", "Arkansas");
                states.Add("CA", "California");
                states.Add("CO", "Colorado");
                states.Add("CT", "Connecticut");
                states.Add("DE", "Delaware");
                states.Add("DC", "District of Columbia");
                states.Add("FL", "Florida");
                states.Add("GA", "Georgia");
                states.Add("HI", "Hawaii");
                states.Add("ID", "Idaho");
                states.Add("IL", "Illinois");
                states.Add("IN", "Indiana");
                states.Add("IA", "Iowa");
                states.Add("KS", "Kansas");
                states.Add("KY", "Kentucky");
                states.Add("LA", "Louisiana");
                states.Add("ME", "Maine");
                states.Add("MD", "Maryland");
                states.Add("MA", "Massachusetts");
                states.Add("MI", "Michigan");
                states.Add("MN", "Minnesota");
                states.Add("MS", "Mississippi");
                states.Add("MO", "Missouri");
                states.Add("MT", "Montana");
                states.Add("NE", "Nebraska");
                states.Add("NV", "Nevada");
                states.Add("NH", "New Hampshire");
                states.Add("NJ", "New Jersey");
                states.Add("NM", "New Mexico");
                states.Add("NY", "New York");
                states.Add("NC", "North Carolina");
                states.Add("ND", "North Dakota");
                states.Add("OH", "Ohio");
                states.Add("OK", "Oklahoma");
                states.Add("OR", "Oregon");
                states.Add("PA", "Pennsylvania");
                states.Add("RI", "Rhode Island");
                states.Add("SC", "South Carolina");
                states.Add("SD", "South Dakota");
                states.Add("TN", "Tennessee");
                states.Add("TX", "Texas");
                states.Add("UT", "Utah");
                states.Add("VT", "Vermont");
                states.Add("VA", "Virginia");
                states.Add("WA", "Washington");
                states.Add("WV", "West Virginia");
                states.Add("WI", "Wisconsin");
                states.Add("WY", "Wyoming");
            }

            if (states.ContainsKey(abbreviation))
                return (states[abbreviation]);
            
            return "Unknown";
        }
    }
}
