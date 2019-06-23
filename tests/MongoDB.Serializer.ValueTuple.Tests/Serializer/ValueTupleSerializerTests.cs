using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Moq;
using Xunit;
using MongoDB.Serializer.ValueTuple.Serializer;
using MongoDB.Serializer.ValueTuple.Provider;

namespace MongoDB.Serializer.ValueTuple.Tests.Serializer
{
    public class SimpleClass
    {
        public ValueTuple<bool>? SimpleValueTuple { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            var other = obj as SimpleClass;
            return Equals(SimpleValueTuple, other.SimpleValueTuple);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SimpleValueTuple);
        }
    }

    public class ValueTupleSimpleSerializerTests
    {
        public ValueTupleSimpleSerializerTests()
        {
            BsonSerializer.RegisterSerializationProvider(new ValueTupleSerializerProvider());
        }

        [Fact]
        public void Constructor_with_registry_should_initialize_instance()
        {
            var mockSerializerRegistry= new Mock<IBsonSerializerRegistry>();

            void act() => new ValueTupleSerializer<bool>(mockSerializerRegistry.Object);

            act();
        }

        [Fact]
        public void Serialize_should_serialize_null()
        {
            var value = new SimpleClass { SimpleValueTuple = null };
            var expectedValue = "{ \"SimpleValueTuple\" : null }";

            var result = value.ToJson();

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Serialize_should_serialize_value()
        {
            var value = new SimpleClass { SimpleValueTuple = new ValueTuple<bool>(true) };
            var expectedValue = "{ \"SimpleValueTuple\" : [true] }";

            var result = value.ToJson();
            
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_null()
        {
            var value = "{ \"SimpleValueTuple\" : null }";
            var expectedValue = new SimpleClass { SimpleValueTuple = null };

            var result = BsonSerializer.Deserialize<SimpleClass>(value);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Deserialize_should_deserialize_value()
        {
            var value = "{ \"SimpleValueTuple\" : [true] }";
            var expectedValue = new SimpleClass { SimpleValueTuple = new ValueTuple<bool>(true) };

            var result = BsonSerializer.Deserialize<SimpleClass>(value);

            Assert.Equal(expectedValue, result);
        }
    }
}
