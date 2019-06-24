using Moq;
using Xunit;
using MongoDB.Bson.Serialization;
using MongoDB.Serializer.ValueTuple.Serializer;

namespace MongoDB.Serializer.ValueTuple.Tests.Serializer
{
    [Collection("Registration collection")]
    public class ValueTupleSerializerInitializeTests
    {
        [Fact]
        public void Constructor_with_registry_should_initialize_instance()
        {
            var mockSerializerRegistry = new Mock<IBsonSerializerRegistry>();

            void act() => new ValueTupleSerializer<bool>(mockSerializerRegistry.Object);

            act();
        }
    }
}
