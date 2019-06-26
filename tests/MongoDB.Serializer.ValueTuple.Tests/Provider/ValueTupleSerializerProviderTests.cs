using System;
using Xunit;
using MongoDB.Bson.Serialization;
using MongoDB.Serializer.ValueTuple.Provider;

namespace MongoDB.Serializer.ValueTuple.Tests.Provider
{
    [Collection("Registration collection")]
    public class ValueTupleSerializerProviderTests
    {
        [Theory]
        [InlineData(typeof(object))]
        [InlineData(typeof(TimeSpan))]
        [InlineData(typeof(Tuple<bool>))]
        public void GetSerializer_should_return_null(Type typeShouldNull)
        {
            var provider = new ValueTupleSerializerProvider();

            var result = provider.GetSerializer(typeShouldNull);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(typeof(ValueTuple<bool>))]
        [InlineData(typeof(ValueTuple<bool,bool>))]
        [InlineData(typeof(ValueTuple<bool,bool, bool>))]
        [InlineData(typeof(ValueTuple<bool, bool, bool, bool>))]
        [InlineData(typeof(ValueTuple<bool, bool, bool, bool, bool>))]
        [InlineData(typeof(ValueTuple<bool, bool, bool, bool,bool, bool>))]
        [InlineData(typeof(ValueTuple<bool, bool, bool, bool, bool, bool, bool>))]
        [InlineData(typeof(ValueTuple<bool, bool, bool, bool, bool, bool, bool, ValueTuple<bool>>))]
        public void GetSerializer_should_return_value(Type typeShouldValue)
        {
            var provider = new ValueTupleSerializerProvider();

            var result = provider.GetSerializer(typeShouldValue);

            Assert.NotNull(result);
        }
    }
}
