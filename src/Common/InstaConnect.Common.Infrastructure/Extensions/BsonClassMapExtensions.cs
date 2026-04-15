using System.Linq.Expressions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static class BsonClassMapExtensions
{
    extension<TClass, TMember>(BsonClassMap<TClass> bsonClassMap)
    {
        public BsonMemberMap MapMemberWithoutSerialization(Expression<Func<TClass, TMember>> member)
        {
            return bsonClassMap.MapMember(member).SetShouldSerializeMethod(_ => false);
        }
    }
}
