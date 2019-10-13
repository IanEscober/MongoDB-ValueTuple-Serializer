# MongoDB ValueTuple Serializer
[![Nuget](https://img.shields.io/nuget/v/MongoDB.Serializer.ValueTuple?color=green&style=plastic)](https://www.nuget.org/packages/MongoDB.Serializer.ValueTuple/)
[![Nuget](https://img.shields.io/nuget/dt/MongoDB.Serializer.ValueTuple?color=green&style=plastic)](https://www.nuget.org/packages/MongoDB.Serializer.ValueTuple/)

A serializer and deserializer library for the [ValueTuple](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple?view=netframework-4.8) type introduced in C# 7 for the [MongoDB .NET Driver](https://github.com/mongodb/mongo-csharp-driver). 

## Format
It serializes the ValueTuples as arrays since the names reverts to the default identifiers (`Item1, Item2, ..., Rest`) at runtime. The `TupleElementNameAttribute` which holds the names of the ValueTuples are just attribute decorations. Due to this reflection cannot obtain those names for serialization. Besides ValueTuples are meant to hold related data and not to represent a concrete model, as its core purpose.
### Sample
```csharp
public class ValueTupleModel
{
    public int ID { get; set; } = 123;
    public (bool MyBool, int MyInt) MyTuple { get; set; } = (true, 1);
} 
```
```javascript
ValueTupleModel: {
    ID: 123,
    MyTuple: [true, 1]
}
```

## Usage
From the entrypoint of your project. Call `Register()` to register the libraries `ValueTupleSerializerProvider` to the MongoDB .NET Driver's `BsonSerializerRegistry`.
```csharp
using MongoDB.Serializer.ValueTuple;

//...
ValueTupleSerializerRegistry.Register();
//...
```

## Contribution
Yeet a Pull Request

## License
[MIT](https://github.com/IanEscober/MongoDB-ValueTuple-Serializer/blob/master/License)