using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Xunit;
using MongoDB.Serializer.ValueTuple.Tests.Data;

namespace MongoDB.Serializer.ValueTuple.Tests.Serializer
{
    [Collection("Registration collection")]
    public class ValueTupleSerializerComplexTests
    {
        private const string NULL_SHALLOW_T1 = "{ \"ComplexValueTuple\" : null }";
        private const string NULL_DEEP_T1 = "{ \"ComplexValueTuple\" : [null] }";
        private const string NULL_SHALLOW_TN = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : null }, null]";
        private const string NULL_DEEP_TN = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : [null] }, null]";
        private const string VALUE_T1 = "{ \"ComplexValueTuple\" : [{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }] }";
        private const string VALUE_TN = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : [{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }] }, true]";

        [Fact]
        public void Serialize_should_serialize_null_shallow_T1()
        {
            var value = CreateT1ValueTuple(null);
            var expectedValue = NULL_SHALLOW_T1;

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_null_shallow_Tn()
        {
            var value = CreateTnValueTuple(null);
            var expectedValue = NULL_SHALLOW_TN;

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_null_deep_T1()
        {
            var value = CreateT1ValueTuple(null, true);
            var expectedValue = NULL_DEEP_T1;

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_null_deep_Tn()
        {
            var value = CreateTnValueTuple(null, true);
            var expectedValue = NULL_DEEP_TN;

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
        public void Deserialize_should_deserialize_null_shallow_T1()
        {
            var value = NULL_SHALLOW_T1;
            var expectedValue = CreateT1ValueTuple(null);

            var result = BsonSerializer.Deserialize<ComplexValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_shallow_Tn()
        {
            var value = NULL_SHALLOW_TN;
            var expectedValue = CreateTnValueTuple(null);

            var result = BsonSerializer.Deserialize<(ComplexValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_deep_T1()
        {
            var value = NULL_DEEP_T1;
            var expectedValue = CreateT1ValueTuple(null, true);

            var result = BsonSerializer.Deserialize<ComplexValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_deep_Tn()
        {
            var value = NULL_DEEP_TN;
            var expectedValue = CreateTnValueTuple(null, true);

            var result = BsonSerializer.Deserialize<(ComplexValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value_T1()
        {
            var value = VALUE_T1;
            var expectedValue = CreateT1ValueTuple(true);

            var result = BsonSerializer.Deserialize<ComplexValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value_Tn()
        {
            var value = VALUE_TN;
            var expectedValue = CreateTnValueTuple(true);

            var result = BsonSerializer.Deserialize<(ComplexValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }

        private ComplexValueTupleModel CreateT1ValueTuple(bool? value, bool isDeep = false)
        {
            var complexValueTuple = new ComplexValueTupleModel { ComplexValueTuple = null };
            if (value is null && isDeep)
            {
                complexValueTuple.ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(null);
            }
            else if (value != null)
            {
                var simpleValueTuple = new SimpleValueTupleModel { SimpleValueTuple = new ValueTuple<bool>(true) };
                complexValueTuple.ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(simpleValueTuple);
            }
            return complexValueTuple;
        }

        private (ComplexValueTupleModel, bool?) CreateTnValueTuple(bool? value, bool isDeep = false)
        {
            var complexValueTuple = new ComplexValueTupleModel { ComplexValueTuple = null };
            if (value is null && isDeep)
            {
                complexValueTuple.ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(null);
            }
            else if (value != null)
            {
                var simpleValueTuple = new SimpleValueTupleModel { SimpleValueTuple = new ValueTuple<bool>(true) };
                complexValueTuple.ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(simpleValueTuple);
            }
            return (complexValueTuple, value);
        }
    }
}
