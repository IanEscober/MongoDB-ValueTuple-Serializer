using System;

namespace MongoDB.Serializer.ValueTuple.Tests.Data
{
    public class ComplexValueTupleModel
    {
        public ValueTuple<SimpleValueTupleModel>? ComplexValueTuple { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            var other = obj as ComplexValueTupleModel;
            return Equals(ComplexValueTuple, other.ComplexValueTuple);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ComplexValueTuple);
        }
    }
}
