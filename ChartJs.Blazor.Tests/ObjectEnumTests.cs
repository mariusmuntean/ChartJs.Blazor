using ChartJs.Blazor.ChartJS.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Globalization;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public class ObjectEnumTests
    {
        // TODO: Refactor into multiple different classes for the different supported types, equality and a general one

        private class TestObjectEnum : ObjectEnum
        {
            public static TestObjectEnum Null => new TestObjectEnum(null);
            public static TestObjectEnum True => new TestObjectEnum(true);
            public static TestObjectEnum Auto => new TestObjectEnum("auto");
            public static TestObjectEnum CustomBool(bool value) => new TestObjectEnum(value);
            public static TestObjectEnum Int(int value) => new TestObjectEnum(value);
            public static TestObjectEnum Double(double value) => new TestObjectEnum(value);
            public static TestObjectEnum Float(float value) => new TestObjectEnum(value);
            public static TestObjectEnum CustomString(string value) => new TestObjectEnum(value);
            // Only for testing!
            public static TestObjectEnum CustomObject(object value) => new TestObjectEnum(value);

            private TestObjectEnum(string value) : base(value) { }
            private TestObjectEnum(int value) : base(value) { }
            private TestObjectEnum(float value) : base(value) { }
            private TestObjectEnum(double value) : base(value) { }
            private TestObjectEnum(bool value) : base(value) { }
            // Only for testing!
            private TestObjectEnum(object value) : base(value) { }
        }

        private class DoubleStringEnum : ObjectEnum
        {
            public static DoubleStringEnum CustomString(string value) => new DoubleStringEnum(value);
            public static DoubleStringEnum CustomDouble(double value) => new DoubleStringEnum(value);

            private DoubleStringEnum(string value) : base(value) { }
            private DoubleStringEnum(double value) : base(value) { }
        }

        [Fact]
        public void Construct_NullValue_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TestObjectEnum.Null);
            Assert.Throws<ArgumentNullException>(() => TestObjectEnum.CustomString(null));
        }

        #region Equality

        [Fact]
        public void Equals_IntEnumsAndIntEnum_ReturnsTrue()
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
        public void Equals_IntEnumsAndInt_ReturnsTrue()
        {
            // Arrange
            const int ExampleIntValue = 10;
            var a = TestObjectEnum.Int(ExampleIntValue);

            // Act
            bool equal = a.Equals(ExampleIntValue);

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

        /// TODO: More equality tests (null, ==, same reference, etc)!

        #endregion

        #region Serialization

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

        #endregion

        #region Deserialization

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

        #endregion
    }
}
