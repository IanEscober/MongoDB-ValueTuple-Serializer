using System;
using System.Reflection;
using System.Collections.Generic;
using MongoDB.Bson.Serialization;
using MongoDB.Serializer.ValueTuple.Serializer;

namespace MongoDB.Serializer.ValueTuple.Provider
{
    public class ValueTupleSerializerProvider : IBsonSerializationProvider
    {
        private readonly Dictionary<Type,Type> _valueTupleSerializerTypes;

        public ValueTupleSerializerProvider()
        {
            _valueTupleSerializerTypes = new Dictionary<Type, Type>
            {
                { typeof(ValueTuple<>), typeof(ValueTupleSerializer<>) },
                { typeof(ValueTuple<,>), typeof(ValueTupleSerializer<,>) },
                { typeof(ValueTuple<,,>), typeof(ValueTupleSerializer<,,>) },
                { typeof(ValueTuple<,,,>), typeof(ValueTupleSerializer<,,,>) },
                { typeof(ValueTuple<,,,,>), typeof(ValueTupleSerializer<,,,,>) },
                { typeof(ValueTuple<,,,,,>), typeof(ValueTupleSerializer<,,,,,>) },
                { typeof(ValueTuple<,,,,,,>), typeof(ValueTupleSerializer<,,,,,,>) },
                { typeof(ValueTuple<,,,,,,,>), typeof(ValueTupleSerializer<,,,,,,,>) },
            };
        }

        public IBsonSerializer GetSerializer(Type type)
        {
            if (type.IsGenericType && !type.ContainsGenericParameters)
            {
                var genericTypeDefinition = type.GetGenericTypeDefinition();

                if(_valueTupleSerializerTypes.TryGetValue(genericTypeDefinition, out var genericType))
                {
                    return GetValueTupleSerializer(genericType.MakeGenericType(type.GenericTypeArguments));
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
