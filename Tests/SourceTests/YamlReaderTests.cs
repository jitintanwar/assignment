using Assignment.Source;
using System.IO;
using Xunit;

namespace Tests.SourceTests
{
    public class YamlReaderTests
    {
        [Fact]
        public void ReadDataSuccess()
        {
            // Arrange
            var location = "D:\\Jitin\\Assignment\\feed-products\\capterra.yaml";
            var jsonreader = new YamlReader();

            // Act
            var result = jsonreader.ReadData(location);

            // Assert
            Assert.Equal("GitGHub", result[0].Name);
            Assert.Equal("github", result[0].Twitter);
            Assert.Equal("Bugs & Issue Tracking,Development Tools", result[0].Categories);
        }

        [Fact]
        public void ReadDataFail()
        {
            // Arrange
            var location = "feed-products\\capterra.yaml";
            var jsonreader = new JsonReader();

            // Act & Assert            
            Assert.Throws<DirectoryNotFoundException>(() => jsonreader.ReadData(location));
        }
    }
}
