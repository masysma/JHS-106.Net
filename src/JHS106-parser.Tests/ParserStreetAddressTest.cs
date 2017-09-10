using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JHS106.Parser.Tests
{
    [TestClass]
    public class ParserStreetAddressTest
    {
        #region Street name parsing

        [TestMethod]
        public void Parser_CommonAddress_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Kettulankatu";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
        }

        [TestMethod]
        public void Parser_MultiWordStreetName_ReturnsValues()
        {
            // Arrange
            var target = new Parser();
            var input = "Urho Kekkosen katu";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Urho Kekkosen katu", result.StreetName);
        }

        #endregion

        #region Special characters

        [TestMethod]
        public void Parser_BeginsWithSpecialCharacter_ReturnsValueAndIsCapitalized()
        {
            // Arrange
            var target = new Parser();
            var input = "Örkkitie";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Örkkitie", result.StreetName);
        }

        [TestMethod]
        public void Parser_ContainsSpecialCharacters_ReturnsValue()
        {
            // Arrange
            var target = new Parser();
            var input = "M\u00F6rk\u00F6katu";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("M\u00F6rk\u00F6katu", result.StreetName);
        }

        [TestMethod]
        public void Parser_ContainsApostrophe_ReturnsValue()
        {
            // Arrange
            var target = new Parser();
            var input = "Tark'ampujankatu";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Tark'ampujankatu", result.StreetName);
        }

        [TestMethod]
        public void Parser_ContainsSemicolon_ReturnsValue()
        {
            // Arrange
            var target = new Parser();
            var input = "Gregorius IX:n tie";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Gregorius IX:n tie", result.StreetName);
        }

        [TestMethod]
        public void Parser_ContainsCharacterWithAcute_ReturnsValue()
        {
            // Arrange
            var target = new Parser();
            var input = "Castr\u00E9nin p.";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Castr\u00E9nin polku", result.StreetName);
        }

        [TestMethod]
        public void Parser_ContainsSlash_ReturnsValue()
        {
            // Arrange
            var target = new Parser();
            var input = "Vihdintie/Nummela KK";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Vihdintie/Nummela KK", result.StreetName);
        }

        #endregion

        #region Capitalization

        [TestMethod]
        public void Parser_NormalStreetName_ReturnsCapitalizedValue()
        {
            // Arrange
            var target = new Parser();
            var input = "kettulankatu";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Kettulankatu", result.StreetName);
        }

        [TestMethod]
        public void Parser_BeginsWithSpecialCharacter_ReturnsCapitalizedValue()
        {
            // Arrange
            var target = new Parser();
            var input = "örkkitie";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Örkkitie", result.StreetName);
        }

        [TestMethod]
        public void Parser_MultiWordStreetName_ReturnsCapitalizedValue()
        {
            // Arrange
            var target = new Parser();
            var input = "urho Kekkosen katu";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Urho Kekkosen katu", result.StreetName);
        }

        [TestMethod]
        public void Parser_MultiWordStreetNameWithDifferentCasing_ReturnsFirstWordAsCapitalizedValue()
        {
            // Arrange
            var target = new Parser();
            var input = "urho kekkosen Katu";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Urho kekkosen Katu", result.StreetName);
        }

        [TestMethod]
        public void Parser_StreetNameWithAcute_ReturnsCapitalizedValue()
        {
            // Arrange
            var target = new Parser();
            var input = "castr\u00E9nin polku";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Castr\u00E9nin polku", result.StreetName);
        }

        [TestMethod]
        public void Parser_StreetNameWithSemicolon_ReturnsCapitalizedValue()
        {
            // Arrange
            var target = new Parser();
            var input = "gregorius ix:n tie";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Gregorius ix:n tie", result.StreetName);
        }

        [TestMethod]
        public void Parser_StreetNameWithSlash_ReturnsCapitalizedValue()
        {
            // Arrange
            var target = new Parser();
            var input = "vihdintie/Nummela KK";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Vihdintie/Nummela KK", result.StreetName);
        }

        [TestMethod]
        public void Parser_StreetNameWithSlash_ReturnsWithFirstWordCapitalizedValue()
        {
            // Arrange
            var target = new Parser();
            var input = "vihdintie/nummela kk";

            // Act
            var result = target.Parse(input);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Vihdintie/nummela kk", result.StreetName);
        }

        #endregion
    }
}
