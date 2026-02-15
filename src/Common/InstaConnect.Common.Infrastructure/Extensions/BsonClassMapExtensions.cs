using System.Linq.Expressions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class BsonClassMapExtensions
{
    public static BsonMemberMap MapMemberWithoutSerialization<TClass, TMember>(this BsonClassMap<TClass> bsonClassMap, Expression<Func<TClass, TMember>> member)
    {
        return bsonClassMap.MapMember(member).SetShouldSerializeMethod(_ => false);
    }
}
