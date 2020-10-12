using ChartJs.Blazor.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Globalization;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public partial class StringEnumTests
    {
        [Fact]
        public void Equals_StringEnumAndStringEnum_ReturnsTrue()
        {
            // Arrange
            var a = TestStringEnum.Auto;
            var b = TestStringEnum.Auto; // different instance, same inner value

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
            var a = TestStringEnum.Custom(ExampleStringValue);

            // Act
            bool equal = a.Equals(ExampleStringValue);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void Equals_EnumAndNull_ReturnsFalse()
        {
            // Arrange
            var a = TestStringEnum.Custom(string.Empty);

            // Act
            bool equal = a.Equals(null);

            // Assert
            Assert.False(equal);
        }

        [Fact]
        public void Equals_SameReference_ReturnsTrue()
        {
            // Arrange
            var a = TestStringEnum.Custom(string.Empty);
            var b = a;

            // Act
            bool equal = a.Equals(b);

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void EqualityOperator_StringEnumAndStringEnum_ReturnsTrue()
        {
            // Arrange
            var a = TestStringEnum.Auto;
            var b = TestStringEnum.Auto; // different instance, same inner value

            // Act
            bool equal = a == b;

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void EqualityOperator_StringEnumAndNull_ReturnsFalse()
        {
            // Arrange
            var a = TestStringEnum.Custom(string.Empty);

            // Act
            bool equal = a == null;

            // Assert
            Assert.False(equal);
        }

        [Fact]
        public void EqualityOperator_NullAndNull_ReturnsTrue()
        {
            // Arrange
            TestStringEnum a = null;

            // Act
            bool equal = a == null;

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void EqualityOperator_SameReference_ReturnsTrue()
        {
            // Arrange
            var a = TestStringEnum.Custom(string.Empty);
            var b = a;

            // Act
            bool equal = a == b;

            // Assert
            Assert.True(equal);
        }

        [Fact]
        public void GetHashCode_InnerValueAndEnum_Equals()
        {
            // Arrange
            const string ExampleString = "asdf";
            TestStringEnum stringEnum = TestStringEnum.Custom(ExampleString);

            // Act
            int hashCodeValue = ExampleString.GetHashCode();
            int hashCodeEnum = stringEnum.GetHashCode();

            // Assert
            Assert.Equal(hashCodeValue, hashCodeEnum);
        }
        
        [Fact]
        public void GetHashCode_EnumAndEnum_Equals()
        {
            // Arrange
            var a = TestStringEnum.Auto;
            var b = TestStringEnum.Auto; // different instance, same inner value

            // Act
            int hashA = a.GetHashCode();
            int hashB = b.GetHashCode();

            // Assert
            Assert.Equal(hashA, hashB);
        }
    }
}
