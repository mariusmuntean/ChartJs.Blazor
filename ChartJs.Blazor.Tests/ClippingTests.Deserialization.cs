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
        public void Deserialize_AllEdgesEqual_FromRoot(int value)
        {
            // Arrange
            string json = value.ToString(CultureInfo.InvariantCulture);
            Clipping expected = new Clipping(value);

            // Act
            Clipping deserialized = JsonConvert.DeserializeObject<Clipping>(json);

            // Assert
            Assert.Equal(expected, deserialized);
        }

        [Fact]
        public void Deserialize_DifferentEdges_FromRoot()
        {
            // Arrange
            const string json = "{\"Bottom\":0,\"Left\":false,\"Top\":10,\"Right\":-100}";
            Clipping expected = new Clipping(top: 10, right: -100, bottom: 0, left: null);

            // Act
            Clipping deserialized = JsonConvert.DeserializeObject<Clipping>(json);

            // Assert
            Assert.Equal(expected, deserialized);
        }

        [Fact]
        public void Deserialize_DifferentEdges_MissingMembers_FromRoot()
        {
            // Arrange
            const string json = "{\"Top\":-123,\"Right\":false}";
            Clipping expected = new Clipping(top: -123);

            // Act
            Clipping deserialized = JsonConvert.DeserializeObject<Clipping>(json);

            // Assert
            Assert.Equal(expected, deserialized);
        }

        [Fact]
        public void Deserialize_DifferentEdges_AdditionalMembers_FromRoot()
        {
            // Arrange
            const string json = "{\"Left\":500,\"Top\":false,\"ABC\":19.2}";
            Clipping expected = new Clipping(left: 500);

            // Act
            Clipping deserialized = JsonConvert.DeserializeObject<Clipping>(json);

            // Assert
            Assert.Equal(expected, deserialized);
        }

        [Fact]
        public void Deserialize_Double_ThrowsJsonReaderException()
        {
            // Arrange
            const string json = "19.2";

            // Act & Assert
            Assert.Throws<JsonReaderException>(() => JsonConvert.DeserializeObject<Clipping>(json));
        }

        [Fact]
        public void Deserialize_Array_ThrowsJsonReaderException()
        {
            // Arrange
            const string json = "[]";

            // Act & Assert
            Assert.Throws<JsonReaderException>(() => JsonConvert.DeserializeObject<Clipping>(json));
        }

        [Fact]
        public void Deserialize_String_ThrowsJsonReaderException()
        {
            // Arrange
            const string json = "\"asdf\"";

            // Act & Assert
            Assert.Throws<JsonReaderException>(() => JsonConvert.DeserializeObject<Clipping>(json));
        }
    }
}
