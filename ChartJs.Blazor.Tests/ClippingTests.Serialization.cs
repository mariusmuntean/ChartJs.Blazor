using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.LineChart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    public partial class ClippingTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(100)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void Serialize_AllEdgesEqual_AsRoot(int value)
        {
            // Arrange
            string Expected = value.ToString(CultureInfo.InvariantCulture);
            Clipping clipping = new Clipping(value);

            // Act
            string serialized = JsonConvert.SerializeObject(clipping);

            // Assert
            Assert.Equal(Expected, serialized);
        }

        [Fact]
        public void Serialize_DifferentEdges_AsRoot()
        {
            // Arrange
            const string Expected = "{\"Top\":0,\"Right\":false,\"Bottom\":10,\"Left\":-100}";
            Clipping clipping = new Clipping(top: 0, right: null, bottom: 10, left: -100);

            // Act
            string serialized = JsonConvert.SerializeObject(clipping);

            // Assert
            Assert.Equal(Expected, serialized);
        }
    }
}
