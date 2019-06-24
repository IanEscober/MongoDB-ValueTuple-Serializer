using MongoDB.Bson.Serialization;
using MongoDB.Serializer.ValueTuple.Provider;

namespace MongoDB.Serializer.ValueTuple.Tests
{
    public class RegistrationFixture
    {
        public RegistrationFixture()
        {
            BsonSerializer.RegisterSerializationProvider(new ValueTupleSerializerProvider());
        }
    }
}
