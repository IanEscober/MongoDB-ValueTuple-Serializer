using System;

namespace MongoDB.Serializer.ValueTuple.Tests.Data
{
    public class SimpleValueTupleModel
    {
        public ValueTuple<bool>? SimpleValueTuple { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            var other = obj as SimpleValueTupleModel;
            return Equals(SimpleValueTuple, other.SimpleValueTuple);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SimpleValueTuple);
        }
    }
}
