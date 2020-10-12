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
        public void Construct_NullValue_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TestStringEnum.Custom(null));
        }
    }
}
