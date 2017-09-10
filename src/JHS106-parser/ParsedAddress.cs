namespace JHS106.Parser
{
    /// <summary>
    /// Class containing the parsed address
    /// </summary>
    public class ParsedAddress
    {
        /// <summary>
        /// Street name e.g. "Tarkk'ampujankatu"
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// House number, e.g. "9" or "12-14"
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Start number (in case of a combined property), e.g. "12"
        /// </summary>
        public string StartNumber { get; set; } 
    /// <summary>
    /// End number (in case of a combined property), e.g. "14"
    /// </summary>
        public string EndNumber { get; set; }


        public string NumberPart { get; set; }
        public string NumberPartition { get; set; }

        /// <summary>
        /// Building, e.g. "2"
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Stairway, e.g. "B"
        /// </summary>
        public string Stairway { get; set; } // rappu, esim B

        /// <summary>
        /// Apartment, e.g. 34b
        /// </summary>
        public string Apartment { get; set; } // huoneisto, esim 34b

        /// <summary>
        /// Apartment number, e.g. 34
        /// </summary>
        public string ApartmentNumber { get; set; } // huoneiston numero, esim 34

        /// <summary>
        /// Apartment partition (in case of when the original apartment has been divided to multiple apartments), e.g. b
        /// </summary>
        public string ApartmentPartition { get; set; } 

        /// <summary>
        /// Postal code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Post office
        /// </summary>
        public string PostOffice { get; set; }
}
}
