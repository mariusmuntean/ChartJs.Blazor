using ChartJs.Blazor.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Globalization;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public partial class StringEnumTests
    {
        private class TestStringEnum : StringEnum
        {
            public static TestStringEnum Auto => new TestStringEnum("auto");
            public static TestStringEnum Custom(string value) => new TestStringEnum(value);

            private TestStringEnum(string stringRep) : base(stringRep) { }
        }
    }
}
