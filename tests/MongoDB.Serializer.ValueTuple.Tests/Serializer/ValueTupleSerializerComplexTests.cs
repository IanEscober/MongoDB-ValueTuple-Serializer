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
        [Fact]
        public void Serialize_should_serialize_null_shallow_T1()
        {
            var value = new ComplexValueTupleModel { ComplexValueTuple = null };
            var expectedValue = "{ \"ComplexValueTuple\" : null }";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_null_shallow_Tn()
        {
            var complexValueTuple = new ComplexValueTupleModel { ComplexValueTuple = null };
            bool? nullableBool = null;
            var value = (complexValueTuple, nullableBool);
            var expectedValue = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : null }, null]";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_null_deep_T1()
        {
            var value = new ComplexValueTupleModel{ ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(null) };
            var expectedValue = "{ \"ComplexValueTuple\" : [null] }";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_null_deep_Tn()
        {
            var complexValueTuple = new ComplexValueTupleModel { ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(null) };
            bool? nullableBool = null;
            var value = (complexValueTuple, nullableBool);
            var expectedValue = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : [null] }, null]";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_value_T1()
        {
            var value = new ComplexValueTupleModel
            {
                ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(
                    new SimpleValueTupleModel
                    {
                        SimpleValueTuple = new ValueTuple<bool>(true)
                    })
            };
            var expectedValue = "{ \"ComplexValueTuple\" : [{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }] }";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_value_Tn()
        {
            var complexValueTuple = new ComplexValueTupleModel
            {
                ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(
                    new SimpleValueTupleModel
                    {
                        SimpleValueTuple = new ValueTuple<bool>(true)
                    })
            };
            bool? nullableBool = true;
            var value = (complexValueTuple, nullableBool);
            var expectedValue = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : [{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }] }, true]";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_shallow_T1()
        {
            var value = "{ \"ComplexValueTuple\" : null }"; 
            var expectedValue = new ComplexValueTupleModel { ComplexValueTuple = null };

            var result = BsonSerializer.Deserialize<ComplexValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_shallow_Tn()
        {   
            var value = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : null }, null]";
            var complexValueTuple = new ComplexValueTupleModel { ComplexValueTuple = null };
            bool? nullableBool = null;
            var expectedValue = (complexValueTuple, nullableBool);

            var result = BsonSerializer.Deserialize<(ComplexValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_deep_T1()
        {
            var value = "{ \"ComplexValueTuple\" : [null] }";
            var expectedValue = new ComplexValueTupleModel { ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(null) };

            var result = BsonSerializer.Deserialize<ComplexValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null_deep_Tn()
        {
            var value = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : [null] }, null]";
            var complexValueTuple = new ComplexValueTupleModel { ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(null) };
            bool? nullableBool = null;
            var expectedValue = (complexValueTuple, nullableBool);

            var result = BsonSerializer.Deserialize<(ComplexValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value_T1()
        {
            var value = "{ \"ComplexValueTuple\" : [{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }] }";
            var expectedValue = new ComplexValueTupleModel
            {
                ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(
                    new SimpleValueTupleModel
                    {
                        SimpleValueTuple = new ValueTuple<bool>(true)
                    })
            };

            var result = BsonSerializer.Deserialize<ComplexValueTupleModel>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value_Tn()
        {
            var value = "[{ \"_t\" : \"ComplexValueTupleModel\", \"ComplexValueTuple\" : [{ \"_t\" : \"SimpleValueTupleModel\", \"SimpleValueTuple\" : [true] }] }, true]";
                var complexValueTuple = new ComplexValueTupleModel
            {
                ComplexValueTuple = new ValueTuple<SimpleValueTupleModel>(
                    new SimpleValueTupleModel
                    {
                        SimpleValueTuple = new ValueTuple<bool>(true)
                    })
            };
            bool? nullableBool = true;
            var expectedValue = (complexValueTuple, nullableBool);

            var result = BsonSerializer.Deserialize<(ComplexValueTupleModel, bool?)>(value);

            Assert.Equal(expectedValue, result);
        }
    }
}
