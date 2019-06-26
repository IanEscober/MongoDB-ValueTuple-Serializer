
namespace MongoDB.Serializer.ValueTuple.Tests
{
    public class RegistrationFixture
    {
        public RegistrationFixture()
        {
            ValueTupleSerializerRegistry.Register();
        }
    }
}
