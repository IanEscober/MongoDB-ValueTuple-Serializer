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
        private const string NULL_T1 = "{ \"SimpleValueTuple\" : null }";
        private const string VALUE_T1 = "{ \"SimpleValueTuple\" : [true] }";
        private const string NULL_TN = "[{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : null }, null]";
        private const string VALUE_TN = "[{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }, true]";

        [Fact]
        public void Serialize_should_serialize_null_T1()
        {
            var value = CreateT1ValueTuple(null);
            var expectedValue = NULL_T1;

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_null_Tn()
        {
            var value = CreateTnValueTuple(null);
            var expectedValue = NULL_TN;

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_value_T1()
        {
            var value = CreateT1ValueTuple(true);
            var expectedValue = VALUE_T1;

            var result = value.ToJson();
            
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_value_Tn()
        {
            var value = CreateTnValueTuple(true);
            var expectedValue = VALUE_TN;

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_T1()
        {
            var value = NULL_T1;
            var expectedValue = CreateT1ValueTuple(null);

            var result = BsonSerializer.Deserialize<SimpleValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_Tn()
        {
            var value = NULL_TN;
            var expectedValue = CreateTnValueTuple(null);

            var result = BsonSerializer.Deserialize<(SimpleValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value_T1()
        {
            var value = VALUE_T1;
            var expectedValue = CreateT1ValueTuple(true);

            var result = BsonSerializer.Deserialize<SimpleValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value_Tn()
        {
            var value = VALUE_TN;
            var expectedValue = CreateTnValueTuple(true);

            var result = BsonSerializer.Deserialize<(SimpleValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }

        private SimpleValueTupleModel CreateT1ValueTuple(bool? value)
        {
            var simpleValueTuple = new SimpleValueTupleModel { SimpleValueTuple = null };
            if (value != null)
            {
                simpleValueTuple.SimpleValueTuple = new ValueTuple<bool>(value.Value);
            }
            return simpleValueTuple;
        }

        private (SimpleValueTupleModel, bool?) CreateTnValueTuple(bool? value)
        {
            var simpleValueTuple = new SimpleValueTupleModel { SimpleValueTuple = null };
            if (value != null)
            {
                simpleValueTuple.SimpleValueTuple = new ValueTuple<bool>(value.Value);
            }
            return (simpleValueTuple, value);
        }
    }
}
