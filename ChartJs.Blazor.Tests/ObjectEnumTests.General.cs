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
        public void Construct_NullValue_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TestObjectEnum.Null);
            Assert.Throws<ArgumentNullException>(() => TestObjectEnum.CustomString(null));
        }

        [Fact]
        public void Deserialize_EnumWithoutConstructor_ThrowsNotSupportedException()
        {
            // Arrange
            const string json = "\"asdf\"";

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => JsonConvert.DeserializeObject<EnumWithoutConstructor>(json));
        }
    }
}
