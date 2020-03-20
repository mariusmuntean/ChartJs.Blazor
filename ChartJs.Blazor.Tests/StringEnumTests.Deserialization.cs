using ChartJs.Blazor.ChartJS.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Globalization;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public partial class StringEnumTests
    {
        [Theory]
        [InlineData("\"foo\"", "foo")]
        [InlineData("\"Hello World!\"", "Hello World!")]
        [InlineData("\"\\\"That's what!\\\", she said.\"", "\"That's what!\", she said.")]
        [InlineData("\"¨öä$ü¨^'{}][\\\\|/-.,+-/*\"", "¨öä$ü¨^'{}][\\|/-.,+-/*")]
        public void Deserialize_StringEnum_FromRoot(string json, string expectedValue)
        {
            // Act
            TestStringEnum stringEnum = JsonConvert.DeserializeObject<TestStringEnum>(json);

            // Assert
            Assert.True(stringEnum.Equals(expectedValue)); // expects all the equality stuff to be correct
        }

        [Fact]
        public void Deserialize_Int_ThrowsNotSupported()
        {
            // Arrange
            const string json = "0";

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.DeserializeObject<TestStringEnum>(json));
        }

        [Fact]
        public void Deserialize_Double_ThrowsNotSupported()
        {
            // Arrange
            const string json = "0.0";

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.DeserializeObject<TestStringEnum>(json));
        }

        [Fact]
        public void Deserialize_JsonArray_ThrowsNotSupported()
        {
            // Arrange
            const string json = "[1,2,3]";

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.DeserializeObject<TestStringEnum>(json));
        }

        [Fact]
        public void Deserialize_JsonObject_ThrowsNotSupported()
        {
            // Arrange
            string json = "{}";

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.DeserializeObject<TestStringEnum>(json));
        }

        [Fact]
        public void Deserialize_Null_ReturnsNull()
        {
            // Arrange
            string json = "null";

            // Act
            TestStringEnum stringEnum = JsonConvert.DeserializeObject<TestStringEnum>(json);

            // Assert
            Assert.Null(stringEnum);
        }

        [Fact]
        public void Deserialize_Undefined_ReturnsNull()
        {
            // Arrange
            string json = "undefined";

            // Act
            TestStringEnum stringEnum = JsonConvert.DeserializeObject<TestStringEnum>(json);

            // Assert
            Assert.Null(stringEnum);
        }
    }
}
