using InstaConnect.Common.Domain.Extensions;

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace InstaConnect.Common.Infrastructure.Helpers.Conventions;

public class SnakeCaseElementNameConvention : ConventionBase, IMemberMapConvention
{
    public void Apply(BsonMemberMap memberMap)
    {
        memberMap.SetElementName(memberMap.MemberName.ToSnakeCase());
    }
}

