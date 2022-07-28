using DAL;
using DAL.Models;
using System.Collections.Generic;
using Xunit;

namespace Tests.DALTests
{
    public class SqlProductRepositoryTests
    {
        [Fact]
        public async void UpdateInventorySuccess()
        {
            // Arrange
            var sqlProductRepository = new SqlProductRepository();
            var products = new List<ProductDTO>() { };

            // Act
            var result = await sqlProductRepository.UpdateInventory(products);

            // Assert
            Assert.False(result);
        }
    }
}
