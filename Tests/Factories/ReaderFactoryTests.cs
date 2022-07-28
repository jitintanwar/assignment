using Assignment.Factories;
using Assignment.Source;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Factories
{
    public class ReaderFactoryTests
    {
        private MockRepository mockRepository;
        private Mock<IServiceProvider> mockServiceProvider;

        public ReaderFactoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockServiceProvider = this.mockRepository.Create<IServiceProvider>();
        }

        [Fact]
        public void ReaderObjectSuccess()
        {
            // Arrange
            this.mockServiceProvider.Setup(x => x.GetService(typeof(JsonReader))).Returns(new JsonReader());

            // Act
            var readerFactory = new ReaderFactory(this.mockServiceProvider.Object);
            var reader = readerFactory.GetReader("json");

            // Assert
            Assert.IsType<JsonReader>(reader);
        }

        [Fact]
        public void ReaderObjectFail()
        {
            // Arrange
            this.mockServiceProvider.Setup(x => x.GetService(typeof(JsonReader))).Returns(new JsonReader());
            var readerFactory = new ReaderFactory(this.mockServiceProvider.Object);

            // Act & Assert

            Assert.Throws<NotImplementedException>(() => readerFactory.GetReader("abcd"));
        }
    }
}
