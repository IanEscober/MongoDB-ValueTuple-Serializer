using MongoDB.Bson.Serialization;
using MongoDB.Serializer.ValueTuple.Provider;

namespace MongoDB.Serializer.ValueTuple
{
    public static class ValueTupleSerializerRegistry
    {
        public static void Register()
        {
            BsonSerializer.RegisterSerializationProvider(new ValueTupleSerializerProvider());
        }
    }
}
