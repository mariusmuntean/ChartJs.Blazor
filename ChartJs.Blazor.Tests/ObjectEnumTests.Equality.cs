using ChartJs.Blazor.ChartJS.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Globalization;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public partial class ObjectEnumTests
    {
        [Fact]
        public void Equals_IntEnumAndIntEnum_ReturnsTrue()
        {
            // Arrange
            const int ExampleIntValue = 10;
            var a = TestObjectEnum.Int(ExampleIntValue);
            var b = TestObjectEnum.Int(ExampleIntValue);

            // Act
            bool equal = a.Equals(b);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void Equals_IntEnumAndInt_ReturnsTrue()
        {
            // Arrange
            const int ExampleIntValue = 10;
            var a = TestObjectEnum.Int(ExampleIntValue);

            // Act
            bool equal = a.Equals(ExampleIntValue);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void Equals_StringEnumAndStringEnum_ReturnsTrue()
        {
            // Arrange
            var a = TestObjectEnum.Auto;
            var b = TestObjectEnum.Auto; // different instance, same inner value

            // Act
            bool equal = a.Equals(b);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void Equals_StringEnumAndString_ReturnsTrue()
        {
            // Arrange
            const string ExampleStringValue = "abcdefg";
            var a = TestObjectEnum.CustomString(ExampleStringValue);

            // Act
            bool equal = a.Equals(ExampleStringValue);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void Equals_DoubleEnumAndDoubleEnum_ReturnsTrue()
        {
            // Arrange
            const double ExampleDoubleValue = 123.456;
            var a = TestObjectEnum.Double(ExampleDoubleValue);
            var b = TestObjectEnum.Double(ExampleDoubleValue);

            // Act
            bool equal = a.Equals(b);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void Equals_DoubleEnumAndDouble_ReturnsTrue()
        {
            // Arrange
            const double ExampleDoubleValue = 123.456;
            var a = TestObjectEnum.Double(ExampleDoubleValue);

            // Act
            bool equal = a.Equals(ExampleDoubleValue);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void Equals_EnumAndNull_ReturnsFalse()
        {
            // Arrange
            var a = TestObjectEnum.CustomObject(new object());

            // Act
            bool equal = a.Equals(null);

            // Assert
            Assert.False(equal);
        }

        [Fact]
        public void Equals_SameReference_ReturnsTrue()
        {
            // Arrange
            var a = TestObjectEnum.CustomObject(new object());
            var b = a;

            // Act
            bool equal = a.Equals(b);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void EqualityOperator_IntEnumAndIntEnum_ReturnsTrue()
        {
            // Arrange
            const int ExampleIntValue = 10;
            var a = TestObjectEnum.Int(ExampleIntValue);
            var b = TestObjectEnum.Int(ExampleIntValue);

            // Act
            bool equal = a == b;

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void EqualityOperator_StringEnumAndStringEnum_ReturnsTrue()
        {
            // Arrange
            var a = TestObjectEnum.Auto;
            var b = TestObjectEnum.Auto; // different instance, same inner value

            // Act
            bool equal = a == b;

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void EqualityOperator_DoubleEnumAndDoubleEnum_ReturnsTrue()
        {
            // Arrange
            const double ExampleDoubleValue = 123.456;
            var a = TestObjectEnum.Double(ExampleDoubleValue);
            var b = TestObjectEnum.Double(ExampleDoubleValue);

            // Act
            bool equal = a == b;

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void EqualityOperator_EnumAndNull_ReturnsFalse()
        {
            // Arrange
            var a = TestObjectEnum.CustomObject(new object());

            // Act
            bool equal = a == null;

            // Assert
            Assert.False(equal);
        }

        [Fact]
        public void EqualityOperator_NullAndNull_ReturnsTrue()
        {
            // Arrange
            TestObjectEnum a = null;

            // Act
            bool equal = a == null;

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void EqualityOperator_SameReference_ReturnsTrue()
        {
            // Arrange
            var a = TestObjectEnum.CustomObject(new object());
            var b = a;

            // Act
            bool equal = a == b;

            // Assert
            Assert.True(equal);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(123.456)]
        [InlineData("asdf")]
        [InlineData(false)]
        public void GetHashCode_InnerValueAndEnum_Equals(object value)
        {
            // Arrange
            TestObjectEnum objEnum = TestObjectEnum.CustomObject(value);

            // Act
            int hashCodeValue = value.GetHashCode();
            int hashCodeEnum = objEnum.GetHashCode();

            // Assert
            Assert.Equal(hashCodeValue, hashCodeEnum);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-654.321)]
        [InlineData("fdsa")]
        [InlineData(true)]
        public void GetHashCode_EnumAndEnum_Equals(object value)
        {
            // Arrange
            var a = TestObjectEnum.CustomObject(value);
            var b = TestObjectEnum.CustomObject(value);

            // Act
            int hashA = a.GetHashCode();
            int hashB = b.GetHashCode();

            // Assert
            Assert.Equal(hashA, hashB);
        }
    }
}