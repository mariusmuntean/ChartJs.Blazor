using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace ChartJs.Blazor.Tests
{
    // TODO Remove before merging, this class is just a playground to check json.net behaviour
    public class ASDF
    {
        [JsonConverter(typeof(MyObjConverter))]
        class MyObj
        {
            public object Value { get; set; }
            public JsonToken TokenType { get; set; }
        }

        class TestObj
        {
            public MyObj Object { get; set; }
        }

        private class MyObjConverter : JsonConverter<MyObj>
        {
            public override MyObj ReadJson(JsonReader reader, Type objectType, [AllowNull] MyObj existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                Console.WriteLine($"Reading into {objectType.FullName}");
                Console.WriteLine($"reader.Value.GetType() = {reader.Value.GetType().FullName}");

                return new MyObj
                {
                    Value = reader.Value.GetType().FullName,
                    TokenType = reader.TokenType
                };
            }

            public override void WriteJson(JsonWriter writer, [AllowNull] MyObj value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

        [Theory]
        [InlineData("{\"Object\":\"asdf\"}", "System.String")]
        [InlineData("{\"Object\":\"true\"}", "System.String")]
        [InlineData("{\"Object\":12}", "System.Int64")]
        [InlineData("{\"Object\":-10}", "System.Int64")]
        [InlineData("{\"Object\":0}", "System.Int64")]
        [InlineData("{\"Object\":100}", "System.Int64")]
        [InlineData("{\"Object\":100000}", "System.Int64")]
        [InlineData("{\"Object\":100000000}", "System.Int64")]
        [InlineData("{\"Object\":10000000000000000000000}", "System.Numerics.BigInteger")]
        [InlineData("{\"Object\":50.123}", "System.Double")]
        [InlineData("{\"Object\":2.3}", "System.Double")]
        [InlineData("{\"Object\":-1.6}", "System.Double")]
        [InlineData("{\"Object\":-100.123}", "System.Double")]
        [InlineData("{\"Object\":-321321.321321}", "System.Double")]
        [InlineData("{\"Object\":true}", "System.Boolean")]
        [InlineData("{\"Object\":false}", "System.Boolean")]
        [InlineData("{\"Object\":{}}", "System.Object")]
        [InlineData("{\"Object\":{\"ABC\":\"EFG\"}}", "System.Object")]
        [InlineData("{\"Object\":[]}", "System.Object")]
        [InlineData("{\"Object\":[\"asdf\", \"ssss\"]}", "System.Object")]
        public void Test(string json, string typeName)
        {
            TestObj obj = JsonConvert.DeserializeObject<TestObj>(json);
            Assert.Equal(typeName, obj.Object.Value as string);
        }
    }
}
