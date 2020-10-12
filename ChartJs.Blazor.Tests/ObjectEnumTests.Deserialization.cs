using ChartJs.Blazor.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Globalization;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public partial class ObjectEnumTests
    {
        [Theory]
        [InlineData("0", 0)]
        [InlineData("10", 10)]
        [InlineData("-1234567489", -1234567489)]
        public void Deserialize_IntEnum_FromRoot(string json, int expectedValue)
        {
            // Act
            TestObjectEnum objEnum = JsonConvert.DeserializeObject<TestObjectEnum>(json);

            // Assert
            Assert.True(objEnum.Equals(expectedValue)); // expects all the equality stuff to be correct
        }

        [Theory]
        // [InlineData("0", 0.0)] this would fail because it gets serialized as int, not double
        [InlineData("0.0", 0.0)]
        [InlineData("123.456", 123.456)]
        [InlineData("-654.321", -654.321)]
        public void Deserialize_DoubleEnum_FromRoot(string json, double expectedValue)
        {
            // Act
            TestObjectEnum objEnum = JsonConvert.DeserializeObject<TestObjectEnum>(json);

            // Assert
            Assert.True(objEnum.Equals(expectedValue)); // expects all the equality stuff to be correct
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("10", 10)]
        [InlineData("-1234567489", -1234567489)]
        public void Deserialize_DoubleEnumThroughInt_FromRoot(string json, double expectedValue)
        {
            // Act
            // the json would result in an int being deserialized but since there is no int
            // that would fail. So instead it uses the double constructor.
            DoubleStringEnum objEnum = JsonConvert.DeserializeObject<DoubleStringEnum>(json);

            // Assert
            Assert.True(objEnum.Equals(expectedValue)); // expects all the equality stuff to be correct
        }

        [Theory]
        [InlineData("\"Hello World!\"", "Hello World!")]
        [InlineData("\"\\\"That's what!\\\", she said.\"", "\"That's what!\", she said.")]
        [InlineData("\"¨öä$ü¨^'{}][\\\\|/-.,+-/*\"", "¨öä$ü¨^'{}][\\|/-.,+-/*")]
        public void Deserialize_StringEnum_FromRoot(string json, string expectedValue)
        {
            // Act
            TestObjectEnum objEnum = JsonConvert.DeserializeObject<TestObjectEnum>(json);

            // Assert
            Assert.True(objEnum.Equals(expectedValue)); // expects all the equality stuff to be correct
        }

        [Fact]
        public void Deserialize_BigIntegerEnum_ThrowsNotSupported()
        {
            // Arrange
            string json = $"{ulong.MaxValue}"; // bigger than long.MaxValue

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.DeserializeObject<TestObjectEnum>(json));
        }

        [Fact]
        public void Deserialize_JsonArray_ThrowsNotSupported()
        {
            // Arrange
            const string json = "[1,2,3]";

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.DeserializeObject<TestObjectEnum>(json));
        }

        [Fact]
        public void Deserialize_JsonObject_ThrowsNotSupported()
        {
            // Arrange
            string json = "{}";

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.DeserializeObject<TestObjectEnum>(json));
        }

        [Fact]
        public void Deserialize_Null_ReturnsNull()
        {
            // Arrange
            string json = "null";

            // Act
            TestObjectEnum objEnum = JsonConvert.DeserializeObject<TestObjectEnum>(json);

            // Assert
            Assert.Null(objEnum);
        }

        [Fact]
        public void Deserialize_Undefined_ReturnsNull()
        {
            // Arrange
            string json = "undefined";

            // Act
            TestObjectEnum objEnum = JsonConvert.DeserializeObject<TestObjectEnum>(json);

            // Assert
            Assert.Null(objEnum);
        }
    }
}
