using System;
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Serializer.ValueTuple.Serializer;

namespace MongoDB.Serializer.ValueTuple.Provider
{
    public class ValueTupleSerializerProvider : IBsonSerializationProvider
    {
        public IBsonSerializer GetSerializer(Type type)
        {
            if (type.IsGenericType && !type.ContainsGenericParameters)
            {
                var genericType = type.GetGenericTypeDefinition();

                if (genericType == typeof(ValueTuple<>))
                {
                    var valueTupleSerializer = typeof(ValueTupleSerializer<>).MakeGenericType(type.GenericTypeArguments);
                    return GetValueTupleSerializer(valueTupleSerializer);
                }
                else if (genericType == typeof(ValueTuple<,>))
                {
                    var valueTupleSerializer = typeof(ValueTupleSerializer<,>).MakeGenericType(type.GenericTypeArguments);
                    return GetValueTupleSerializer(valueTupleSerializer);
                }
            }
            return null;
        }

        private static IBsonSerializer GetValueTupleSerializer(Type valueTupleSerializer)
        {
            var valueTupleSerializerInfo = valueTupleSerializer.GetTypeInfo();

            var valueTupleSerializerConstructor = valueTupleSerializerInfo.GetConstructor(new[] { typeof(IBsonSerializerRegistry) });
            if (valueTupleSerializerConstructor is null)
            {
                throw new MissingMethodException("No constructor found for ValueTuple serializer");
            }            
            return valueTupleSerializerConstructor.Invoke(new object[] { BsonSerializer.SerializerRegistry }) as IBsonSerializer;
        }
    }
}
