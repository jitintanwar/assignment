using Assignment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Utilities
{
    public class InputValidatorTests
    {
        [Fact]
        public void ValidateReturnsTrue()
        {
            // Assert
            var inputValidator = new InputValidator();

            // Act
            var result = inputValidator.Validate("capterra", "abc.xyz");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateReturnsFalse()
        {
            // Assert
            var inputValidator = new InputValidator();

            // Act
            var result = inputValidator.Validate("capterra", "");

            // Assert
            Assert.False(result);
        }
    }
}
