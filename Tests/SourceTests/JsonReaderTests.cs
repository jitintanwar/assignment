using Assignment.Source;
using System.IO;
using Xunit;

namespace Tests.SourceTests
{
    public class JsonReaderTests
    {

        [Fact]
        public void ReadDataSuccess()
        {
            // Arrange
            var location = "D:\\Jitin\\Assignment\\feed-products\\softwareadvice.json";
            var jsonreader = new JsonReader();

            // Act
            var result = jsonreader.ReadData(location);

            // Assert
            Assert.Equal("Freshdesk", result[0].Name);
            Assert.Equal("@freshdesk", result[0].Twitter);
            Assert.Equal("Customer Service, Call Center", result[0].Categories);
        }

        [Fact]
        public void ReadDataFail()
        {
            // Arrange
            var location = "feed-products\\softwareadvice.json";
            var jsonreader = new JsonReader();

            // Act & Assert            
            Assert.Throws<DirectoryNotFoundException>(() => jsonreader.ReadData(location));
        }
    }
}
