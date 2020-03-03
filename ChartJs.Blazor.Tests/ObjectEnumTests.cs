using ChartJs.Blazor.ChartJS.Common.Enums;
using System;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public class ObjectEnumTests
    {
        private class TestObjectEnum : ObjectEnum
        {
            public static TestObjectEnum Null => new TestObjectEnum(null);
            public static TestObjectEnum True => new TestObjectEnum(true);
            public static TestObjectEnum Int(int value) => new TestObjectEnum(value);
            public static TestObjectEnum Double(double value) => new TestObjectEnum(value);
            public static TestObjectEnum Float(float value) => new TestObjectEnum(value);

            private TestObjectEnum(string value) : base(value) { }
            private TestObjectEnum(int value) : base(value) { }
            private TestObjectEnum(float value) : base(value) { }
            private TestObjectEnum(double value) : base(value) { }
            private TestObjectEnum(bool value) : base(value) { }
        }

        [Fact]
        public void Construct_NullValue_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TestObjectEnum.Null);
        }

        [Fact]
        public void Equals_IntEnumsAndIntEnum_ReturnsTrue()
        {
            const int ExampleIntValue = 10;
            var a = TestObjectEnum.Int(ExampleIntValue);
            var b = TestObjectEnum.Int(ExampleIntValue);

            Assert.True(a.Equals(b));
        }
    }
}
