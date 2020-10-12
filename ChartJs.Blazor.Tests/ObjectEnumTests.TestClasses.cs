using ChartJs.Blazor.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Globalization;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public partial class ObjectEnumTests
    {
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

        private class EnumWithoutConstructor : ObjectEnum
        {
            // no suitable (supported) constructor
            private EnumWithoutConstructor(object value) : base(value) { }
        }
    }
}
