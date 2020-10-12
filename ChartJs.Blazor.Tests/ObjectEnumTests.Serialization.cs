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
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void Serialize_IntEnum_AsRoot(int value)
        {
            // Arrange
            TestObjectEnum objEnum = TestObjectEnum.Int(value);

            // Act
            string serialized = JsonConvert.SerializeObject(objEnum);

            // Assert
            Assert.Equal(value.ToString(CultureInfo.InvariantCulture), serialized);
        }

        [Theory]
        [InlineData(123.456)]
        [InlineData(-654.321)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        public void Serialize_DoubleEnum_AsRoot(double value)
        {
            // Arrange
            TestObjectEnum objEnum = TestObjectEnum.Double(value);

            // Act
            string serialized = JsonConvert.SerializeObject(objEnum);

            // Assert
            Assert.Equal(value.ToString(CultureInfo.InvariantCulture), serialized);
        }

        [Fact]
        public void Serialize_DoubleEnumZero_AsRoot()
        {
            // Arrange
            TestObjectEnum objEnum = TestObjectEnum.Double(0);

            // Act
            string serialized = JsonConvert.SerializeObject(objEnum);

            // Assert
            Assert.Equal("0.0", serialized);
        }

        [Fact]
        public void Serialize_FloatEnum_ThrowsNotSupported()
        {
            // Arrange
            TestObjectEnum objEnum = TestObjectEnum.Float(15.2f);

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.SerializeObject(objEnum));
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("bar")]
        [InlineData("whomst'd've'ly'yaint'nt'ed'ies's'y'es")]
        [InlineData("\"That's what!\", she said.")]
        [InlineData("\uD83D\uDE42 emoji shenanigans")]
        [InlineData("¨öä$ü¨^'{}][\\|/-.,+-/*")]
        public void Serialize_StringEnum_AsRoot(string value)
        {
            // Arrange
            TestObjectEnum objEnum = TestObjectEnum.CustomString(value);
            string escapedValue = JsonConvert.ToString(value);

            // Act
            string serialized = JsonConvert.SerializeObject(objEnum);

            // Assert
            Assert.Equal(escapedValue, serialized);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Serialize_BoolEnum_AsRoot(bool value)
        {
            // Arrange
            TestObjectEnum objEnum = TestObjectEnum.CustomBool(value);
            string escapedValue = JsonConvert.ToString(value);

            // Act
            string serialized = JsonConvert.SerializeObject(objEnum);

            // Assert
            Assert.Equal(escapedValue, serialized);
        }
    }
}
