using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JHS106.Parser.Tests
{
    [TestClass]
    public class ParserHouseNumberTest
    {
        #region Street number parsing

        [TestMethod]
        public void Parser_CommonAddress_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu 2";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("2", result.Number);
            Assert.AreEqual("2", result.NumberPart);
        }

        [TestMethod]
        public void Parser_CommonAddressWithNumberPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu 2a";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("2a", result.Number);
            Assert.AreEqual("2", result.NumberPart);
            Assert.AreEqual("a", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_CommonAddressWithUpperCaseNumberPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu 2A";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("2a", result.Number);
            Assert.AreEqual("2", result.NumberPart);
            Assert.AreEqual("a", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_CommonAddressWithMultipartNumberPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu 2a-b";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("2a-b", result.Number);
            Assert.AreEqual("2", result.NumberPart);
            Assert.AreEqual("a-b", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_CommonAddressWithUpperCaseMultipartNumberPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu 2A-B";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("2a-b", result.Number);
            Assert.AreEqual("2", result.NumberPart);
            Assert.AreEqual("a-b", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_CommonAddressWithCombinedPropertyNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu 2-4";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("2-4", result.Number);
            Assert.AreEqual("2", result.StartNumber);
            Assert.AreEqual("4", result.EndNumber);
        }

        [TestMethod]
        public void Parser_CommonAddressWithCombinedPropertyNumberAndNumberPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu 2-4b";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
            Assert.AreEqual("2-4b", result.Number);
            Assert.AreEqual("2", result.StartNumber);
            Assert.AreEqual("4", result.EndNumber);
            Assert.AreEqual("b", result.NumberPartition);
        }

        #endregion

        #region Special characters in street names with street numbers



        [TestMethod]
        public void Parser_SpecialCharactersWithNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "\u00C4mm\u00E4l\u00E4nkatu 1";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("\u00C4mm\u00E4l\u00E4nkatu", result.StreetName);
            Assert.AreEqual("1", result.Number);
            Assert.AreEqual("1", result.NumberPart);
        }

        [TestMethod]
        public void Parser_SpecialCharactersWithNumberAndPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "\u00C4mm\u00E4l\u00E4nkatu 1b";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("\u00C4mm\u00E4l\u00E4nkatu", result.StreetName);
            Assert.AreEqual("1b", result.Number);
            Assert.AreEqual("1", result.NumberPart);
            Assert.AreEqual("b", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_SpecialCharactersWithCombinedPropertyNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "\u00C4mm\u00E4l\u00E4nkatu 1-3";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("\u00C4mm\u00E4l\u00E4nkatu", result.StreetName);
            Assert.AreEqual("1-3", result.Number);
            Assert.AreEqual("1", result.StartNumber);
            Assert.AreEqual("3", result.EndNumber);
        }

        [TestMethod]
        public void Parser_ApostropheWithNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Tark'ampujankatu 10";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Tark'ampujankatu", result.StreetName);
            Assert.AreEqual("10", result.Number);
            Assert.AreEqual("10", result.NumberPart);
        }

        [TestMethod]
        public void Parser_ApostropheWithNumberAndPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Tark'ampujankatu 10a";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Tark'ampujankatu", result.StreetName);
            Assert.AreEqual("10a", result.Number);
            Assert.AreEqual("10", result.NumberPart);
            Assert.AreEqual("a", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_ApostropheWithCombinedPropertyNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Tark'ampujankatu 10-12";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Tark'ampujankatu", result.StreetName);
            Assert.AreEqual("10-12", result.Number);
            Assert.AreEqual("10", result.StartNumber);
            Assert.AreEqual("12", result.EndNumber);
        }

        [TestMethod]
        public void Parser_SemicolonWithNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Gregorius IX:n tie 12";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Gregorius IX:n tie", result.StreetName);
            Assert.AreEqual("12", result.Number);
            Assert.AreEqual("12", result.NumberPart);
        }

        [TestMethod]
        public void Parser_SemicolonWithNumberAndPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Gregorius IX:n tie 12a";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Gregorius IX:n tie", result.StreetName);
            Assert.AreEqual("12a", result.Number);
            Assert.AreEqual("12", result.NumberPart);
            Assert.AreEqual("a", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_SemicolonWithCombinedPropertyNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Gregorius IX:n tie 12-14";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Gregorius IX:n tie", result.StreetName);
            Assert.AreEqual("12-14", result.Number);
            Assert.AreEqual("12", result.StartNumber);
            Assert.AreEqual("14", result.EndNumber);
        }

        [TestMethod]
        public void Parser_AcuteWithNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Castr\u00E9nin polku 12";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Castr\u00E9nin polku", result.StreetName);
            Assert.AreEqual("12", result.Number);
            Assert.AreEqual("12", result.NumberPart);
        }

        [TestMethod]
        public void Parser_AcuteWithNumberAndPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Castr\u00E9nin polku 12a";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Castr\u00E9nin polku", result.StreetName);
            Assert.AreEqual("12a", result.Number);
            Assert.AreEqual("12", result.NumberPart);
            Assert.AreEqual("a", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_AcuteWithCombinedPropertyNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Castr\u00E9nin polku 12-14";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Castr\u00E9nin polku", result.StreetName);
            Assert.AreEqual("12-14", result.Number);
            Assert.AreEqual("12", result.StartNumber);
            Assert.AreEqual("14", result.EndNumber);
        }

        [TestMethod]
        public void Parser_SlashWithNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Vihdintie/Nummela KK 12";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Vihdintie/Nummela KK", result.StreetName);
            Assert.AreEqual("12", result.Number);
            Assert.AreEqual("12", result.NumberPart);
        }

        [TestMethod]
        public void Parser_SlashWithNumberAndPartition_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Vihdintie/Nummela KK 12a";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Vihdintie/Nummela KK", result.StreetName);
            Assert.AreEqual("12a", result.Number);
            Assert.AreEqual("12", result.NumberPart);
            Assert.AreEqual("a", result.NumberPartition);
        }

        [TestMethod]
        public void Parser_SlashWithCombinedPropertyNumber_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Vihdintie/Nummela KK 12-14";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Vihdintie/Nummela KK", result.StreetName);
            Assert.AreEqual("12-14", result.Number);
            Assert.AreEqual("12", result.StartNumber);
            Assert.AreEqual("14", result.EndNumber);
        }

        #endregion
        
    }
}
