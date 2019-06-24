using Moq;
using Xunit;
using MongoDB.Bson.Serialization;
using MongoDB.Serializer.ValueTuple.Serializer;
using MongoDB.Serializer.ValueTuple.Tests.Data;

namespace MongoDB.Serializer.ValueTuple.Tests.Serializer
{
    [Collection("Registration collection")]
    public class ValueTupleSerializerInitializeTests
    {
        [Fact]
        public void Constructor_with_registry_should_initialize_instance_Simple_T1()
        {
            var mockSerializerRegistry = new Mock<IBsonSerializerRegistry>();

            void act() => new ValueTupleSerializer<SimpleValueTupleModel>(mockSerializerRegistry.Object);

            act();
        }

        [Fact]
        public void Constructor_with_registry_should_initialize_instance_Simple_Tn()
        {
            var mockSerializerRegistry = new Mock<IBsonSerializerRegistry>();

            void act() => new ValueTupleSerializer<(SimpleValueTupleModel, bool?)>(mockSerializerRegistry.Object);

            act();
        }

        [Fact]
        public void Constructor_with_registry_should_initialize_instance_Complex_T1()
        {
            var mockSerializerRegistry = new Mock<IBsonSerializerRegistry>();

            void act() => new ValueTupleSerializer<ComplexValueTupleModel>(mockSerializerRegistry.Object);

            act();
        }

        [Fact]
        public void Constructor_with_registry_should_initialize_instance_Complex_Tn()
        {
            var mockSerializerRegistry = new Mock<IBsonSerializerRegistry>();

            void act() => new ValueTupleSerializer<(ComplexValueTupleModel, bool?)>(mockSerializerRegistry.Object);

            act();
        }
    }
}
