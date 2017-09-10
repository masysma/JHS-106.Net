using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JHS106.Parser
{
    public class Parser
    {
        public ParsedAddress Parse(string addressText)
        {
            var result = new ParsedAddress();

            var addressLines = addressText.Split('\n', ',');

            fillStreetName(addressLines, ref result);
            if (addressLines.Length > 1)
            {
                fillPostalAddress(addressLines, ref result);
            }

            return result;
        }

        private void fillPostalAddress(string[] addressLines, ref ParsedAddress result)
        {
            var postalLine = addressLines[addressLines.Length - 1];
            if (string.IsNullOrWhiteSpace(postalLine))
            {
                return;
            }
            postalLine = postalLine.Trim();


            const string postalCode = "(?:FI-)?[\\d]{5}";
            const string postalOffice = "(?:[" + Pattern.ALL_LETTERS + "]+[\\s]{0,1})+";

            const string regexPattern = "(" + postalCode + ")?[\\s]{0,1}(" + postalOffice + ")?";

            // Fill results
            var postalAddressresult = matchRegex(postalLine, regexPattern);
            result.PostalCode = postalAddressresult[1];
            result.PostOffice = postalAddressresult[2];

            // Clean up results
            result.PostOffice = result.PostOffice.ToUpper();
            if (result.PostalCode.StartsWith("FI-", StringComparison.OrdinalIgnoreCase))
            {
                result.PostalCode = result.PostalCode.Remove(0, 3);
            }
        }

        private void fillStreetName(string[] addressLines, ref ParsedAddress result)
        {
            var streetLine = addressLines[0];
            if (string.IsNullOrWhiteSpace(streetLine))
            {
                return;
            }
            streetLine = streetLine.Trim();


            const string streetName = "(?:[" + Pattern.ALL_CHARACTERS + "]+[\\s]{0,1})+";
            const string addressNumber = "(?:([0-9]+)(?:([" + Pattern.ALL_LETTERS + "][-]?[" + Pattern.ALL_LETTERS + "]?)?|(?:[-]([0-9]+)(?:([" + Pattern.ALL_LETTERS + "])?)?)?)?(?:(?:[/]|(?:[\\s]rak[\\.]?[\\s]))([0-9]+))?)";
            const string stairway = "(?:[" + Pattern.ALL_LETTERS + "]{1}|as|as\\.|bst|bst\\.)";
            const string apartment = "(?:[0]{0,2})([0-9]{1,3})([" + Pattern.ALL_LETTERS + "])?";

            const string regexPattern = "(" + streetName + ")(?:" + addressNumber + ")?[\\s]{0,1}(" + stairway + ")?[\\s]{0,1}(?:" + apartment + ")?";

            var parts = matchRegex(streetLine, regexPattern);
            result.StreetName = parts[1];

            if (parts.Length == 20)
            {
                // Multiple matches --> combined property house number. Map parts from secong match group.
                parts[4] = parts[12];
                parts[5] = parts[13];
                parts[6] = parts[14];
                parts[7] = parts[17];
            }

            result.Number = parts[2]
                + parts[3]
                + (string.IsNullOrEmpty(parts[4]) ? "" : "-" + parts[4])
                + (string.IsNullOrEmpty(parts[5]) ? "" : parts[5])
                + (string.IsNullOrEmpty(parts[6]) ? "" : "/" + parts[6]);


            if (!string.IsNullOrEmpty(parts[2]) && string.IsNullOrEmpty(parts[4]))
            {
                result.NumberPart = parts[2];
            }

            if (!string.IsNullOrEmpty(parts[3]))
            {
                result.NumberPartition = parts[3];
            }
            if (!string.IsNullOrEmpty(parts[5]))
            {
                result.NumberPartition = parts[5];
            }

            if (!string.IsNullOrEmpty(parts[4]))
            {
                result.StartNumber = parts[2];
                result.EndNumber = parts[4];
            }

            result.Building = parts[6];
            result.Stairway = parts[7];

            result.Apartment = parts[8] + parts[9];
            result.ApartmentNumber = parts[8];
            result.ApartmentPartition = parts[9];

            // Clean up 
            result.StreetName = result.StreetName.Trim();
            result.StreetName = result.StreetName.Substring(0, 1).ToUpper() + result.StreetName.Substring(1);
            result.StreetName = unabbreviate(result.StreetName);

            result.Number = result.Number.ToLower();

            if (result.NumberPartition != null)
            {
                result.NumberPartition = result.NumberPartition.ToLower();
            }

            result.ApartmentPartition = result.ApartmentPartition.ToLower();
            result.Apartment = result.Apartment?.ToLower();
            result.Stairway = result.Stairway.ToUpper();
        }

        private string unabbreviate(string str)
        {
            foreach (var streetNameAbreviation in Abbreviations.StreetNameAbreviations)
            {
                if (str.EndsWith(streetNameAbreviation.Value))
                {
                    return replaceLastOccurrence(str, streetNameAbreviation.Value, streetNameAbreviation.Key);
                }
            }
            return str;
        }

        private string replaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }


        private string[] matchRegex(string inputString, string matchPattern)
        {
            Match m;
            List<string> results = new List<string>();

            try
            {
                m = Regex.Match(inputString, matchPattern,
                    RegexOptions.Compiled,
                    TimeSpan.FromSeconds(1));

                while (m.Success)
                {
                    foreach (Group mGroup in m.Groups)
                    {
                        results.Add(mGroup.Value);
                    }
                    m = m.NextMatch();
                }
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("The matching operation timed out.");
            }

            return results.ToArray();
        }

    }
}