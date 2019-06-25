using System;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Serializer.ValueTuple.Serializer
{
    public class ValueTupleSerializer<T1> : StructSerializerBase<ValueTuple<T1>>
    {
        private readonly Lazy<IBsonSerializer<T1>> _lazyItem1Serializer;

        public ValueTupleSerializer(IBsonSerializerRegistry serializerRegistry)
        {
            if (serializerRegistry is null)
            {
                throw new ArgumentNullException("serializerRegistry");
            }

            _lazyItem1Serializer = new Lazy<IBsonSerializer<T1>>(() => serializerRegistry.GetSerializer<T1>());
        }

        public override ValueTuple<T1> Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var item1 = _lazyItem1Serializer.Value.Deserialize(context);
            context.Reader.ReadEndArray();

            return new ValueTuple<T1>(item1);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ValueTuple<T1> value)
        {
            context.Writer.WriteStartArray();
            _lazyItem1Serializer.Value.Serialize(context, args, value.Item1);
            context.Writer.WriteEndArray();
        }
    }

    public class ValueTupleSerializer<T1, T2> : StructSerializerBase<ValueTuple<T1, T2>>
    {
        private readonly Lazy<IBsonSerializer<T1>> _lazyItem1Serializer;
        private readonly Lazy<IBsonSerializer<T2>> _lazyItem2Serializer;


        public ValueTupleSerializer(IBsonSerializerRegistry serializerRegistry)
        {
            if (serializerRegistry is null)
            {
                throw new ArgumentNullException("serializerRegistry");
            }

            _lazyItem1Serializer = new Lazy<IBsonSerializer<T1>>(() => serializerRegistry.GetSerializer<T1>());
            _lazyItem2Serializer = new Lazy<IBsonSerializer<T2>>(() => serializerRegistry.GetSerializer<T2>());
        }

        public override (T1, T2) Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var item1 = _lazyItem1Serializer.Value.Deserialize(context);
            var item2 = _lazyItem2Serializer.Value.Deserialize(context);
            context.Reader.ReadEndArray();

            return (item1, item2);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, (T1, T2) value)
        {
            context.Writer.WriteStartArray();
            _lazyItem1Serializer.Value.Serialize(context, args, value.Item1);
            _lazyItem2Serializer.Value.Serialize(context, args, value.Item2);
            context.Writer.WriteEndArray();
        }
    }

    public class ValueTupleSerializer<T1, T2, T3> : StructSerializerBase<ValueTuple<T1, T2, T3>>
    {
        private readonly Lazy<IBsonSerializer<T1>> _lazyItem1Serializer;
        private readonly Lazy<IBsonSerializer<T2>> _lazyItem2Serializer;
        private readonly Lazy<IBsonSerializer<T3>> _lazyItem3Serializer;


        public ValueTupleSerializer(IBsonSerializerRegistry serializerRegistry)
        {
            if (serializerRegistry is null)
            {
                throw new ArgumentNullException("serializerRegistry");
            }

            _lazyItem1Serializer = new Lazy<IBsonSerializer<T1>>(() => serializerRegistry.GetSerializer<T1>());
            _lazyItem2Serializer = new Lazy<IBsonSerializer<T2>>(() => serializerRegistry.GetSerializer<T2>());
            _lazyItem3Serializer = new Lazy<IBsonSerializer<T3>>(() => serializerRegistry.GetSerializer<T3>());
        }

        public override (T1, T2, T3) Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var item1 = _lazyItem1Serializer.Value.Deserialize(context);
            var item2 = _lazyItem2Serializer.Value.Deserialize(context);
            var item3 = _lazyItem3Serializer.Value.Deserialize(context);
            context.Reader.ReadEndArray();

            return (item1, item2, item3);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, (T1, T2, T3) value)
        {
            context.Writer.WriteStartArray();
            _lazyItem1Serializer.Value.Serialize(context, args, value.Item1);
            _lazyItem2Serializer.Value.Serialize(context, args, value.Item2);
            _lazyItem3Serializer.Value.Serialize(context, args, value.Item3);
            context.Writer.WriteEndArray();
        }
    }

    public class ValueTupleSerializer<T1, T2, T3, T4> : StructSerializerBase<ValueTuple<T1, T2, T3, T4>>
    {
        private readonly Lazy<IBsonSerializer<T1>> _lazyItem1Serializer;
        private readonly Lazy<IBsonSerializer<T2>> _lazyItem2Serializer;
        private readonly Lazy<IBsonSerializer<T3>> _lazyItem3Serializer;
        private readonly Lazy<IBsonSerializer<T4>> _lazyItem4Serializer;

        public ValueTupleSerializer(IBsonSerializerRegistry serializerRegistry)
        {
            if (serializerRegistry is null)
            {
                throw new ArgumentNullException("serializerRegistry");
            }

            _lazyItem1Serializer = new Lazy<IBsonSerializer<T1>>(() => serializerRegistry.GetSerializer<T1>());
            _lazyItem2Serializer = new Lazy<IBsonSerializer<T2>>(() => serializerRegistry.GetSerializer<T2>());
            _lazyItem3Serializer = new Lazy<IBsonSerializer<T3>>(() => serializerRegistry.GetSerializer<T3>());
            _lazyItem4Serializer = new Lazy<IBsonSerializer<T4>>(() => serializerRegistry.GetSerializer<T4>());
        }

        public override (T1, T2, T3, T4) Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var item1 = _lazyItem1Serializer.Value.Deserialize(context);
            var item2 = _lazyItem2Serializer.Value.Deserialize(context);
            var item3 = _lazyItem3Serializer.Value.Deserialize(context);
            var item4 = _lazyItem4Serializer.Value.Deserialize(context);
            context.Reader.ReadEndArray();

            return (item1, item2, item3, item4);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, (T1, T2, T3, T4) value)
        {
            context.Writer.WriteStartArray();
            _lazyItem1Serializer.Value.Serialize(context, args, value.Item1);
            _lazyItem2Serializer.Value.Serialize(context, args, value.Item2);
            _lazyItem3Serializer.Value.Serialize(context, args, value.Item3);
            _lazyItem4Serializer.Value.Serialize(context, args, value.Item4);
            context.Writer.WriteEndArray();
        }
    }

    public class ValueTupleSerializer<T1, T2, T3, T4, T5> : StructSerializerBase<ValueTuple<T1, T2, T3, T4, T5>>
    {
        private readonly Lazy<IBsonSerializer<T1>> _lazyItem1Serializer;
        private readonly Lazy<IBsonSerializer<T2>> _lazyItem2Serializer;
        private readonly Lazy<IBsonSerializer<T3>> _lazyItem3Serializer;
        private readonly Lazy<IBsonSerializer<T4>> _lazyItem4Serializer;
        private readonly Lazy<IBsonSerializer<T5>> _lazyItem5Serializer;

        public ValueTupleSerializer(IBsonSerializerRegistry serializerRegistry)
        {
            if (serializerRegistry is null)
            {
                throw new ArgumentNullException("serializerRegistry");
            }

            _lazyItem1Serializer = new Lazy<IBsonSerializer<T1>>(() => serializerRegistry.GetSerializer<T1>());
            _lazyItem2Serializer = new Lazy<IBsonSerializer<T2>>(() => serializerRegistry.GetSerializer<T2>());
            _lazyItem3Serializer = new Lazy<IBsonSerializer<T3>>(() => serializerRegistry.GetSerializer<T3>());
            _lazyItem4Serializer = new Lazy<IBsonSerializer<T4>>(() => serializerRegistry.GetSerializer<T4>());
            _lazyItem5Serializer = new Lazy<IBsonSerializer<T5>>(() => serializerRegistry.GetSerializer<T5>());
        }

        public override (T1, T2, T3, T4, T5) Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var item1 = _lazyItem1Serializer.Value.Deserialize(context);
            var item2 = _lazyItem2Serializer.Value.Deserialize(context);
            var item3 = _lazyItem3Serializer.Value.Deserialize(context);
            var item4 = _lazyItem4Serializer.Value.Deserialize(context);
            var item5 = _lazyItem5Serializer.Value.Deserialize(context);
            context.Reader.ReadEndArray();

            return (item1, item2, item3, item4, item5);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, (T1, T2, T3, T4, T5) value)
        {
            context.Writer.WriteStartArray();
            _lazyItem1Serializer.Value.Serialize(context, args, value.Item1);
            _lazyItem2Serializer.Value.Serialize(context, args, value.Item2);
            _lazyItem3Serializer.Value.Serialize(context, args, value.Item3);
            _lazyItem4Serializer.Value.Serialize(context, args, value.Item4);
            _lazyItem5Serializer.Value.Serialize(context, args, value.Item5);
            context.Writer.WriteEndArray();
        }
    }

    public class ValueTupleSerializer<T1, T2, T3, T4, T5, T6> : StructSerializerBase<ValueTuple<T1, T2, T3, T4, T5, T6>>
    {
        private readonly Lazy<IBsonSerializer<T1>> _lazyItem1Serializer;
        private readonly Lazy<IBsonSerializer<T2>> _lazyItem2Serializer;
        private readonly Lazy<IBsonSerializer<T3>> _lazyItem3Serializer;
        private readonly Lazy<IBsonSerializer<T4>> _lazyItem4Serializer;
        private readonly Lazy<IBsonSerializer<T5>> _lazyItem5Serializer;
        private readonly Lazy<IBsonSerializer<T6>> _lazyItem6Serializer;

        public ValueTupleSerializer(IBsonSerializerRegistry serializerRegistry)
        {
            if (serializerRegistry is null)
            {
                throw new ArgumentNullException("serializerRegistry");
            }

            _lazyItem1Serializer = new Lazy<IBsonSerializer<T1>>(() => serializerRegistry.GetSerializer<T1>());
            _lazyItem2Serializer = new Lazy<IBsonSerializer<T2>>(() => serializerRegistry.GetSerializer<T2>());
            _lazyItem3Serializer = new Lazy<IBsonSerializer<T3>>(() => serializerRegistry.GetSerializer<T3>());
            _lazyItem4Serializer = new Lazy<IBsonSerializer<T4>>(() => serializerRegistry.GetSerializer<T4>());
            _lazyItem5Serializer = new Lazy<IBsonSerializer<T5>>(() => serializerRegistry.GetSerializer<T5>());
            _lazyItem6Serializer = new Lazy<IBsonSerializer<T6>>(() => serializerRegistry.GetSerializer<T6>());
        }

        public override (T1, T2, T3, T4, T5, T6) Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var item1 = _lazyItem1Serializer.Value.Deserialize(context);
            var item2 = _lazyItem2Serializer.Value.Deserialize(context);
            var item3 = _lazyItem3Serializer.Value.Deserialize(context);
            var item4 = _lazyItem4Serializer.Value.Deserialize(context);
            var item5 = _lazyItem5Serializer.Value.Deserialize(context);
            var item6 = _lazyItem6Serializer.Value.Deserialize(context);
            context.Reader.ReadEndArray();

            return (item1, item2, item3, item4, item5, item6);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, (T1, T2, T3, T4, T5, T6) value)
        {
            context.Writer.WriteStartArray();
            _lazyItem1Serializer.Value.Serialize(context, args, value.Item1);
            _lazyItem2Serializer.Value.Serialize(context, args, value.Item2);
            _lazyItem3Serializer.Value.Serialize(context, args, value.Item3);
            _lazyItem4Serializer.Value.Serialize(context, args, value.Item4);
            _lazyItem5Serializer.Value.Serialize(context, args, value.Item5);
            _lazyItem6Serializer.Value.Serialize(context, args, value.Item6);
            context.Writer.WriteEndArray();
        }
    }

    public class ValueTupleSerializer<T1, T2, T3, T4, T5, T6, T7> : StructSerializerBase<ValueTuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        private readonly Lazy<IBsonSerializer<T1>> _lazyItem1Serializer;
        private readonly Lazy<IBsonSerializer<T2>> _lazyItem2Serializer;
        private readonly Lazy<IBsonSerializer<T3>> _lazyItem3Serializer;
        private readonly Lazy<IBsonSerializer<T4>> _lazyItem4Serializer;
        private readonly Lazy<IBsonSerializer<T5>> _lazyItem5Serializer;
        private readonly Lazy<IBsonSerializer<T6>> _lazyItem6Serializer;
        private readonly Lazy<IBsonSerializer<T7>> _lazyItem7Serializer;

        public ValueTupleSerializer(IBsonSerializerRegistry serializerRegistry)
        {
            if (serializerRegistry is null)
            {
                throw new ArgumentNullException("serializerRegistry");
            }

            _lazyItem1Serializer = new Lazy<IBsonSerializer<T1>>(() => serializerRegistry.GetSerializer<T1>());
            _lazyItem2Serializer = new Lazy<IBsonSerializer<T2>>(() => serializerRegistry.GetSerializer<T2>());
            _lazyItem3Serializer = new Lazy<IBsonSerializer<T3>>(() => serializerRegistry.GetSerializer<T3>());
            _lazyItem4Serializer = new Lazy<IBsonSerializer<T4>>(() => serializerRegistry.GetSerializer<T4>());
            _lazyItem5Serializer = new Lazy<IBsonSerializer<T5>>(() => serializerRegistry.GetSerializer<T5>());
            _lazyItem6Serializer = new Lazy<IBsonSerializer<T6>>(() => serializerRegistry.GetSerializer<T6>());
            _lazyItem7Serializer = new Lazy<IBsonSerializer<T7>>(() => serializerRegistry.GetSerializer<T7>());
        }

        public override (T1, T2, T3, T4, T5, T6, T7) Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var item1 = _lazyItem1Serializer.Value.Deserialize(context);
            var item2 = _lazyItem2Serializer.Value.Deserialize(context);
            var item3 = _lazyItem3Serializer.Value.Deserialize(context);
            var item4 = _lazyItem4Serializer.Value.Deserialize(context);
            var item5 = _lazyItem5Serializer.Value.Deserialize(context);
            var item6 = _lazyItem6Serializer.Value.Deserialize(context);
            var item7 = _lazyItem7Serializer.Value.Deserialize(context);
            context.Reader.ReadEndArray();

            return (item1, item2, item3, item4, item5, item6, item7);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, (T1, T2, T3, T4, T5, T6, T7) value)
        {
            context.Writer.WriteStartArray();
            _lazyItem1Serializer.Value.Serialize(context, args, value.Item1);
            _lazyItem2Serializer.Value.Serialize(context, args, value.Item2);
            _lazyItem3Serializer.Value.Serialize(context, args, value.Item3);
            _lazyItem4Serializer.Value.Serialize(context, args, value.Item4);
            _lazyItem5Serializer.Value.Serialize(context, args, value.Item5);
            _lazyItem6Serializer.Value.Serialize(context, args, value.Item6);
            _lazyItem7Serializer.Value.Serialize(context, args, value.Item7);
            context.Writer.WriteEndArray();
        }
    }

    public class ValueTupleSerializer<T1, T2, T3, T4, T5, T6, T7, TRest> : StructSerializerBase<ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>> where TRest : struct
    {
        private readonly Lazy<IBsonSerializer<T1>> _lazyItem1Serializer;
        private readonly Lazy<IBsonSerializer<T2>> _lazyItem2Serializer;
        private readonly Lazy<IBsonSerializer<T3>> _lazyItem3Serializer;
        private readonly Lazy<IBsonSerializer<T4>> _lazyItem4Serializer;
        private readonly Lazy<IBsonSerializer<T5>> _lazyItem5Serializer;
        private readonly Lazy<IBsonSerializer<T6>> _lazyItem6Serializer;
        private readonly Lazy<IBsonSerializer<T7>> _lazyItem7Serializer;
        private readonly Lazy<IBsonSerializer<TRest>> _lazyRestSerializer;

        public ValueTupleSerializer(IBsonSerializerRegistry serializerRegistry)
        {
            if (serializerRegistry is null)
            {
                throw new ArgumentNullException("serializerRegistry");
            }

            _lazyItem1Serializer = new Lazy<IBsonSerializer<T1>>(() => serializerRegistry.GetSerializer<T1>());
            _lazyItem2Serializer = new Lazy<IBsonSerializer<T2>>(() => serializerRegistry.GetSerializer<T2>());
            _lazyItem3Serializer = new Lazy<IBsonSerializer<T3>>(() => serializerRegistry.GetSerializer<T3>());
            _lazyItem4Serializer = new Lazy<IBsonSerializer<T4>>(() => serializerRegistry.GetSerializer<T4>());
            _lazyItem5Serializer = new Lazy<IBsonSerializer<T5>>(() => serializerRegistry.GetSerializer<T5>());
            _lazyItem6Serializer = new Lazy<IBsonSerializer<T6>>(() => serializerRegistry.GetSerializer<T6>());
            _lazyItem7Serializer = new Lazy<IBsonSerializer<T7>>(() => serializerRegistry.GetSerializer<T7>());
            _lazyRestSerializer = new Lazy<IBsonSerializer<TRest>>(() => serializerRegistry.GetSerializer<TRest>());
        }

        public override ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var item1 = _lazyItem1Serializer.Value.Deserialize(context);
            var item2 = _lazyItem2Serializer.Value.Deserialize(context);
            var item3 = _lazyItem3Serializer.Value.Deserialize(context);
            var item4 = _lazyItem4Serializer.Value.Deserialize(context);
            var item5 = _lazyItem5Serializer.Value.Deserialize(context);
            var item6 = _lazyItem6Serializer.Value.Deserialize(context);
            var item7 = _lazyItem7Serializer.Value.Deserialize(context);
            var rest = _lazyRestSerializer.Value.Deserialize(context);
            context.Reader.ReadEndArray();

            return new ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(item1, item2, item3, item4, item5, item6, item7, rest);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> value)
        {
            context.Writer.WriteStartArray();
            _lazyItem1Serializer.Value.Serialize(context, args, value.Item1);
            _lazyItem2Serializer.Value.Serialize(context, args, value.Item2);
            _lazyItem3Serializer.Value.Serialize(context, args, value.Item3);
            _lazyItem4Serializer.Value.Serialize(context, args, value.Item4);
            _lazyItem5Serializer.Value.Serialize(context, args, value.Item5);
            _lazyItem6Serializer.Value.Serialize(context, args, value.Item6);
            _lazyItem7Serializer.Value.Serialize(context, args, value.Item7);
            _lazyRestSerializer.Value.Serialize(context, args, value.Rest);
            context.Writer.WriteEndArray();
        }
    }
}
