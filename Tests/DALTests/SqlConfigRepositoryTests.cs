using DAL;
using Xunit;

namespace Tests.DALTests
{
    public class SqlConfigRepositoryTests
    {
        [Fact]
        public async void GetDataSuccess()
        {
            // Arrange
            var sqlConfigRepopsitory = new SqlConfigRepopsitory();

            // Act
            var result = await sqlConfigRepopsitory.GetClientConfig("capterra");

            // Assert
            Assert.Equal("yaml", result.ImportType);
            Assert.Equal("capterra", result.ClientName);
        }
    }
}
