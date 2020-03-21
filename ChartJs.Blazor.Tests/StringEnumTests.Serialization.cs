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
        [InlineData("foo")]
        [InlineData("bar")]
        [InlineData("1234567890")]
        [InlineData("")]
        [InlineData("whomst'd've'ly'yaint'nt'ed'ies's'y'es")]
        [InlineData("\"That's what!\", she said.")]
        [InlineData("\uD83D\uDE42 emoji shenanigans")]
        [InlineData("¨öä$ü¨^'{}][\\|/-.,+-/*")]
        public void Serialize_StringEnum_AsRoot(string value)
        {
            // Arrange
            TestStringEnum objEnum = TestStringEnum.Custom(value);
            string escapedValue = JsonConvert.ToString(value);

            // Act
            string serialized = JsonConvert.SerializeObject(objEnum);

            // Assert
            Assert.Equal(escapedValue, serialized);
        }
    }
}
