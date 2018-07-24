using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JHS106.Parser.Tests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void Parser_CommonAddress_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu\n05800 KOUVOLA";

            // Act
            var result = target.Parse(input);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("05800", result.PostalCode);
            Assert.AreEqual("KOUVOLA", result.PostOffice);
        }


        [TestMethod]
        public void Parser_InvalidAddress_ReturnsEmptyValues()
        {
            // Arrange
            var target = new Parser();
            var input = "? ?, ?";

            // Act
            var result = target.Parse(input);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.StreetName);
            Assert.AreEqual("", result.PostalCode);
            Assert.AreEqual("", result.PostOffice);
        }

        [TestMethod]
        public void Parser_AnotherInvalidAddress_ReturnsEmptyValues()
        {
            // Arrange
            var target = new Parser();
            var input = "1 1, 1";

            // Act
            var result = target.Parse(input);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.StreetName);
            Assert.AreEqual("", result.PostalCode);
            Assert.AreEqual("", result.PostOffice);
        }

        [TestMethod]
        public void Parser_CommonAddressPostOfficeWithIncorrectCase_PostOfficeIsCapitalized()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu,05800 koUvoLa";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("05800", result.PostalCode);
            Assert.AreEqual("KOUVOLA", result.PostOffice);
        }

        [TestMethod]
        public void Parser_CommonAddressWithWhitespaceAfterComma_PostalCodeIsTrimmed()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu, 05800 koUvoLa";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("05800", result.PostalCode);
            Assert.AreEqual("KOUVOLA", result.PostOffice);
        }

        [TestMethod]
        public void Parser_LongAddressWithAbbreviatedStreetName_StreetNameIsUnabbreviated()
        {
            // Arrange
            var target = new Parser();
            var input = "Ulla Tapanisen r. 29B d 15B\n37150 NOKIA";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Ulla Tapanisen raitti", result.StreetName);
            Assert.AreEqual("29b", result.Number);
            Assert.AreEqual("29", result.NumberPart);
            Assert.AreEqual("b", result.NumberPartition);
            Assert.AreEqual("D", result.Stairway);
            Assert.AreEqual("15b", result.Apartment);
            Assert.AreEqual("15", result.ApartmentNumber);
            Assert.AreEqual("b", result.ApartmentPartition);
            Assert.AreEqual("37150", result.PostalCode);
            Assert.AreEqual("NOKIA", result.PostOffice);
        }

        [TestMethod]
        public void Parser_SpecialCharactersInPostOffice_PostOfficeCapitalized()
        {
            // Arrange
            var target = new Parser();
            var input = "Ringsbölevägen\n12345 \u00E5land";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Ringsbölevägen", result.StreetName);
            Assert.AreEqual("12345", result.PostalCode);
            Assert.AreEqual("ÅLAND", result.PostOffice);
        }

        [TestMethod]
        public void Parser_PostalAddressSeparatedWithComma_PostalAddressIsReturned()
        {
            // Arrange
            var target = new Parser();
            var input = "Polttolinja,40520 Jyväskylä";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Polttolinja", result.StreetName);
            Assert.AreEqual("40520", result.PostalCode);
            Assert.AreEqual("JYVÄSKYLÄ", result.PostOffice);
        }

        [TestMethod]
        public void Parser_OnlyPostalCodeIsSupplied_PostalCodeIsReturned()
        {
            // Arrange
            var target = new Parser();
            var input = "Polttolinja,40520";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Polttolinja", result.StreetName);
            Assert.AreEqual("40520", result.PostalCode);
        }

        [TestMethod]
        public void Parser_OnlyPostOfficeIsSupplied_PostOfficeIsReturned()
        {
            // Arrange
            var target = new Parser();
            var input = "Polttolinja,Jyväskylä";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Polttolinja", result.StreetName);
            Assert.AreEqual("JYVÄSKYLÄ", result.PostOffice);
        }


        [TestMethod]
        public void Parser_PostOfficeWithWhitespaceIsSupplied_PostOfficeIsReturned()
        {
            // Arrange
            var target = new Parser();
            var input = "Kauppatie,12345 viHti Kk";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kauppatie", result.StreetName);
            Assert.AreEqual("12345", result.PostalCode);
            Assert.AreEqual("VIHTI KK", result.PostOffice);
        }

        [TestMethod]
        public void Parser_PostalCodeWithCoutryCodeIsSupplied_PostalCodeIsReturned()
        {
            // Arrange
            var target = new Parser();
            var input = "Kauppatie,FI-12345 viHti Kk";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kauppatie", result.StreetName);
            Assert.AreEqual("12345", result.PostalCode);
            Assert.AreEqual("VIHTI KK", result.PostOffice);
        }

        [TestMethod]
        public void Parser_CombinedProperty_AddressIsReturned()
        {
            // Arrange
            var target = new Parser();
            var input = "Ritva Valkaman tr. 29-31B d, 12345 Toimipaikka";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Ritva Valkaman tori", result.StreetName);
            Assert.AreEqual("29-31b", result.Number);
            Assert.AreEqual("29", result.StartNumber);
            Assert.AreEqual("31", result.EndNumber);
            Assert.AreEqual("b", result.NumberPartition);
            Assert.AreEqual("D", result.Stairway);
            Assert.AreEqual("12345", result.PostalCode);
            Assert.AreEqual("TOIMIPAIKKA", result.PostOffice);
        }
    }
}
