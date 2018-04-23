using System;
using Xunit;
using LoggingKata;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("-84.677017, 34.073638,\"Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)\"")]
        [InlineData("1,1")]
        [InlineData("1,1,testing")]
        public void ShouldParse(string line)
        {
            // Arrange
            var parser = new TacoParser();

            // Act
            var result = parser.Parse(line);    

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc,abc,abc")]
        [InlineData("1000, 1000, abc")]
        [InlineData("123,123,123")]
        [InlineData(",,")]
        public void ShouldFailParse(string line)
        {
            // Arrange
            var parser = new TacoParser();

            // Act
            var result = parser.Parse(line);

            // Assert
            Assert.Null(result);
        }
    }
}
