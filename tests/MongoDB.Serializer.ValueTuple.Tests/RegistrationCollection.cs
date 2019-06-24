using Xunit;

namespace MongoDB.Serializer.ValueTuple.Tests
{
    [CollectionDefinition("Registration collection")]
    public class RegistrationCollection : ICollectionFixture<RegistrationFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
