using DAL;
using Xunit;

namespace Tests.DALTests
{
    public class SqlConfigRepositoryTests
    {
        [Fact]
        public async void GetClientConfigSuccess()
        {
            // Arrange
            var sqlConfigRepopsitory = new SqlConfigRepopsitory();

            // Act
            var result = await sqlConfigRepopsitory.GetClientConfig("capterra");

            // Assert
            Assert.Equal("yaml", result.ImportType);
            Assert.Equal("capterra", result.ClientName);
        }

        [Fact]
        public async void GetClientConfigFail()
        {
            // Arrange
            var sqlConfigRepopsitory = new SqlConfigRepopsitory();

            // Act
            var result = await sqlConfigRepopsitory.GetClientConfig("xyz");

            // Assert
            Assert.Null(result);
        }
    }
}
