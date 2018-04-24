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
        }

        [Theory]
        [InlineData("-84.677017, 34.073638,\"Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)\"")]
        [InlineData("1,1")]
        [InlineData("1,1,testing")]
        public void ShouldParse(string line)
        {
            var parser = new TacoParser();

            var result = parser.Parse(line);    

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
            var parser = new TacoParser();

            var result = parser.Parse(line);

            Assert.Null(result);
        }
    }
}
