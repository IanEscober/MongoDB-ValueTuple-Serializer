using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Xunit;
using MongoDB.Serializer.ValueTuple.Tests.Data;

namespace MongoDB.Serializer.ValueTuple.Tests.Serializer
{
    [Collection("Registration collection")]
    public class ValueTupleSerializerSimpleTests
    {
        [Fact]
        public void Serialize_should_serialize_null_T1()
        {
            var value = new SimpleValueTupleModel { SimpleValueTuple = null };
            var expectedValue = "{ \"SimpleValueTuple\" : null }";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_null_Tn()
        {
            var simpleValueTuple = new SimpleValueTupleModel { SimpleValueTuple = null };
            bool? nullableBool = null;
            var value = (simpleValueTuple, nullableBool);
            var expectedValue = "[{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : null }, null]";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_value_T1()
        {
            var value = new SimpleValueTupleModel { SimpleValueTuple = new ValueTuple<bool>(true) };
            var expectedValue = "{ \"SimpleValueTuple\" : [true] }";

            var result = value.ToJson();
            
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_value_Tn()
        {
            var simpleValueTuple = new SimpleValueTupleModel { SimpleValueTuple = new ValueTuple<bool>(true) };
            bool? nullableBool = true;
            var value = (simpleValueTuple, nullableBool);
            var expectedValue = "[{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }, true]";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_T1()
        {
            var value = "{ \"SimpleValueTuple\" : null }";
            var expectedValue = new SimpleValueTupleModel { SimpleValueTuple = null };

            var result = BsonSerializer.Deserialize<SimpleValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_Tn()
        {
            var value = "[{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : null }, null]";
            var simpleValueTuple = new SimpleValueTupleModel { SimpleValueTuple = null };
            bool? nullableBool = null;
            var expectedValue = (simpleValueTuple, nullableBool);

            var result = BsonSerializer.Deserialize<(SimpleValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value_T1()
        {
            var value = "{ \"SimpleValueTuple\" : [true] }";
            var expectedValue = new SimpleValueTupleModel { SimpleValueTuple = new ValueTuple<bool>(true) };

            var result = BsonSerializer.Deserialize<SimpleValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value_Tn()
        {
            var value = "[{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }, true]";
            var simpleValueTuple = new SimpleValueTupleModel { SimpleValueTuple = new ValueTuple<bool>(true) };
            bool? nullableBool = true;
            var expectedValue = (simpleValueTuple, nullableBool);

            var result = BsonSerializer.Deserialize<(SimpleValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }
    }
}
